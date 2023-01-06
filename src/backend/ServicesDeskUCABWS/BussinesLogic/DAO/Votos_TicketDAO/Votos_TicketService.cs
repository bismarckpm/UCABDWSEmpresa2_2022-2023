using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO
{
    public class Votos_TicketService : IVotos_TicketDAO
    {
        private readonly IDataContext contexto;
        private readonly ITicketDAO ticketDAO;

        public Votos_TicketService(IDataContext Context, ITicketDAO TicketDAO)
        {
            ticketDAO = TicketDAO;
            contexto = Context;
        }

        public Votos_TicketService(IDataContext Context)
        {
            
            contexto = Context;
        }
        public bool AgregarVoto(List<Votos_Ticket> ListaVotos)
        {
            contexto.Votos_Tickets.AddRange(ListaVotos);
            contexto.DbContext.SaveChanges();
            return true;
        }



        public ApplicationResponse<Votos_Ticket> Votar(Votos_TicketDTOCreate votoDTO)
        {

            var response = new ApplicationResponse<Votos_Ticket>();
            try
            {
                ValidarDatosEntradaVotos(votoDTO);

                Votos_Ticket voto = ActualizarVoto(votoDTO);


                //Verificar Aprobacion
                
                var temp = contexto.Tickets.Include(x => x.Tipo_Ticket)
                    .Where(x => x.Id == voto.IdTicket).First().Tipo_Ticket;

                string veredicto = temp.VerificarVotacion(voto.IdTicket,contexto);
                
                contexto.DbContext.SaveChanges();
                response.Data = voto;

            }
            catch (ExceptionsControl ex)
            {
                response.Exception = ex.Mensaje;
                response.Success = false;

            }

            return response;
        }

        private Votos_Ticket ActualizarVoto(Votos_TicketDTOCreate votoDTO)
        {
            //actualizamos el voto 
            var voto = contexto.Votos_Tickets
                .Where(x => x.IdTicket.ToString().ToUpper() == votoDTO.IdTicket &&
                x.IdUsuario.ToString().ToUpper() == votoDTO.IdUsuario).First();
            voto.comentario = votoDTO.comentario;
            voto.voto = votoDTO.voto;
            voto.fecha = DateTime.UtcNow;
            contexto.DbContext.SaveChanges();
            return voto;
        }

        public void ValidarDatosEntradaVotos(Votos_TicketDTOCreate votosDTO)
        {
            if (votosDTO.comentario.Length > 300)
            {
                throw new ExceptionsControl(ErroresVotos.COMENTARIO_FUERA_RANGO);
            }
                
            var VotosPermitidos = new string[] { "Aprobado", "Rechazado", "Pendiente" };
            if (!VotosPermitidos.Contains(votosDTO.voto))
            {
                throw new ExceptionsControl(ErroresVotos.VOTO_NO_VALIDO);
            }
            var ticket = contexto.Tickets.Include(x => x.Tipo_Ticket).Where(x => x.Id.ToString().ToUpper() == votosDTO.IdTicket.ToUpper()).FirstOrDefault();

            if (ticket == null)
            {
                throw new ExceptionsControl(ErroresVotos.ERROR_TICKET_DESC);
            }
            if (contexto.Usuarios.Where(c=> c.Id.ToString().ToUpper()==votosDTO.IdUsuario.ToUpper()).FirstOrDefault() == null)
            {
                throw new ExceptionsControl(ErroresVotos.ERROR_USUARIO_DESC);
            }
                
            var voto = contexto.Votos_Tickets.Where(x => x.IdTicket.ToString().ToUpper() == votosDTO.IdTicket &&
                    x.IdUsuario.ToString().ToUpper() == votosDTO.IdUsuario.ToUpper()).FirstOrDefault();
            if (voto == null)
            {
                throw new ExceptionsControl(ErroresVotos.VOTO_NO_PERMITIDO);
            }

            if (ticket.Tipo_Ticket.ObtenerTipoAprobacion() == "Modelo_Jerarquico")
            {
                if (ticket.nro_cargo_actual != voto.Turno)
                {
                    throw new ExceptionsControl(ErroresVotos.VOTACION_EXPIRADA);
                }
            }
        }

        public string VerificarAprobacionTicketParalelo(Guid Id)
        {

            try
            {
                var tipo_ticket = contexto.Tickets.Include(x => x.Tipo_Ticket)
                    .Where(x => x.Id == Id).FirstOrDefault();

                var ticket = contexto.Tickets
                    .AsNoTracking().Include(x=>x.Departamento_Destino)
                    .Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                    .Include(x => x.Emisor).ThenInclude(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Where(x => x.Id == Id).FirstOrDefault();

                var votosfavor = contexto.Votos_Tickets.Where(x => x.IdTicket == Id
                && x.voto == "Aprobado").Count();
                if (votosfavor >= tipo_ticket.Tipo_Ticket.Minimo_Aprobado)
                {
                    var empleados = contexto.Empleados.Where(x => x.Id == ticket.Departamento_Destino.id).ToList();
                    ticketDAO.CambiarEstado(ticket, "Aprobado", null);
                    var lista_votos = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();//.ForEach(x=>x.voto="Aprobado");
                    lista_votos.ForEach(x => x.voto = "Aprobado");
                    return "Aprobado";
                }

                var votoscontra = contexto.Votos_Tickets.Where(x => x.IdTicket == Id
                && x.voto == "Rechazado").Count();
                if (votoscontra >= tipo_ticket.Tipo_Ticket.Maximo_Rechazado)
                {
                    var empleados = contexto.Empleados.Where(x => x.Id == ticket.Departamento_Destino.id).ToList();
                    ticketDAO.CambiarEstado(ticket, "Rechazado", null);
                    var lista_votos = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();//.ForEach(x => x.voto = "Rechazado");
                    lista_votos.ForEach(x => x.voto = "Rechazado");
                    return "Rechazado";
                }

                //contexto.SaveChanges();
            }
            catch (Exception)
            {
                return "Fallido";
            }

            return "Pendiente";
        }

        

        public string VerificarAprobacionTicketJerarquico(Guid Id)
        {

            try
            {
                var tipo_ticket = contexto.Tickets.Include(x => x.Tipo_Ticket)
                    .ThenInclude(x => x.Flujo_Aprobacion)
                    .Where(x => x.Id == Id).First();

                var ticket = contexto.Tickets
                    .Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                    .Include(x => x.Emisor).ThenInclude(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Where(x => x.Id == Id).First();

                var minimo_aprobado = tipo_ticket.Tipo_Ticket.Flujo_Aprobacion
                    .Where(x => x.OrdenAprobacion == ticket.nro_cargo_actual)
                    .Select(x => x.Minimo_aprobado_nivel).First();

                var maximo_rechazado = tipo_ticket.Tipo_Ticket.Flujo_Aprobacion
                    .Where(x => x.OrdenAprobacion == ticket.nro_cargo_actual)
                    .Select(x => x.Maximo_Rechazado_nivel).First();

                //contar votos a favor
                var votosfavor = contexto.Votos_Tickets.Where(x => x.IdTicket == Id
                && x.voto == "Aprobado" && x.Turno == ticket.nro_cargo_actual).Count();

                //Buscar votos necesarios para aprobar
                if (votosfavor >= minimo_aprobado)
                {
                    //Cambiar Estado a los votos restantes
                    var lista_votos = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();
                    lista_votos.ForEach(x => x.voto = "Aprobado");

                    //Ingreso siguiente ronda de votos
                    ticket.nro_cargo_actual++;
                    var fin = VotosSiguienteRonda(ticket, tipo_ticket);
                    if (fin)
                    {
                        ticketDAO.CambiarEstado(ticket, "Aprobado",null);
                        return "Aprobado";
                    }
                    return "Pendiente";
                }

                //contar votos en contra
                var votoscontra = contexto.Votos_Tickets.Where(x => x.IdTicket == Id
                && x.voto == "Rechazado" && x.Turno == ticket.nro_cargo_actual).Count();
                if (votoscontra >= maximo_rechazado)
                {
                    //Cambiar Estado a los votos restantes
                    var lista_votos = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();
                    lista_votos.ForEach(x => x.voto = "Rechazado");

                    //Ingreso siguiente ronda de votos
                    var empleados = contexto.Empleados.Where(x => x.Id == ticket.Departamento_Destino.id).ToList();
                    ticketDAO.CambiarEstado(ticket, "Rechazado",null);
                    contexto.DbContext.SaveChanges();
                    //EnviarNotiicacion("Ticket Rechazado")
                    return "Rechazado";

                }

            }
            catch (Exception ex)
            {
                return "Fallido";
            }

            return "Pendiente";
        }

        private bool VotosSiguienteRonda(Ticket ticket, Ticket tipo_ticket)
        {
            if (contexto.Flujos_Aprobaciones
                .Where(x => x.Tipo_Ticket.Id == tipo_ticket.Tipo_Ticket.Id &&
            x.OrdenAprobacion == ticket.nro_cargo_actual).Count() == 0)
            {
                return true;
            }

            var Flujos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Cargo)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket.ToString().ToUpper() == ticket.Tipo_Ticket.Id.ToString().ToUpper() &&
                        x.OrdenAprobacion == ticket.nro_cargo_actual).FirstOrDefault();


            var Cargos = Flujos.Cargo;


            var ListaEmpleado = contexto.Empleados.Where(x => x.Cargo.id == Cargos.id).ToList();


            var ListaVotos = ListaEmpleado.Select(x => new Votos_Ticket
            {
                IdTicket = ticket.Id,
                Ticket = ticket,
                IdUsuario = x.Id,
                Empleado = x,
                voto = "Pendiente",
                Turno = ticket.nro_cargo_actual
            });

            contexto.Votos_Tickets.AddRange(ListaVotos);
            ticketDAO.CambiarEstado(ticket, "Pendiente", ListaEmpleado);
            return false;
        }

        public ApplicationResponse<List<Votos_Ticket>> ConsultaVotos(Guid id)
        {
            var response = new ApplicationResponse<List<Votos_Ticket>>();
            try
            {
                response.Data = contexto.Votos_Tickets
                    .Include(x => x.Ticket).ThenInclude(x=>x.Tipo_Ticket)
                    .Include(x => x.Empleado)
                    .Where(x => x.IdUsuario == id && x.voto == "Pendiente").ToList();
            }
            catch (Exception ex)
            {
                response.Exception = ex.Message;
                response.Success = false;
            }
            return response;
        }

        public ApplicationResponse<List<Votos_Ticket>> ConsultaVotosNoPendientes(Guid id)
        {
            var response = new ApplicationResponse<List<Votos_Ticket>>();
            try
            {
                response.Data = contexto.Votos_Tickets
                    .Include(x => x.Ticket).ThenInclude(x => x.Tipo_Ticket)
                    .Include(x => x.Empleado)
                    .Where(x => x.IdUsuario == id && x.voto != "Pendiente").ToList();
            }
            catch (Exception ex)
            {
                response.Exception = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
