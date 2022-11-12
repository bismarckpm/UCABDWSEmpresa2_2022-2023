using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
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


        public Votos_TicketService(IDataContext Context)
        {
            contexto = Context;
        }

        public bool AgregarVoto(List<Votos_Ticket> ListaVotos)
        {
            contexto.Votos_Tickets.AddRange(ListaVotos);
            contexto.SaveChanges();
            return true;
        }



        public ApplicationResponse<Votos_TicketDTOCreate> Votar(Votos_TicketDTOCreate votoDTO)
        {

            var response = new ApplicationResponse<Votos_TicketDTOCreate>();
            try
            {
                ValidarDatosEntradaVotos(votoDTO);
                var v = new Tipo_Estado("NombrePrueba", "Descripcion Prueba")
                {
                    Id = Guid.Parse("822D08E6-713D-4F03-A634-520693D31E96")
                };
                contexto.Tipo_Estados.Update(v);
                //actualizamos el voto 
                var voto = contexto.Votos_Tickets
                    .Where(x => x.IdTicket.ToString().ToUpper() == votoDTO.IdTicket &&
                    x.IdUsuario.ToString().ToUpper() == votoDTO.IdUsuario).First();
                voto.comentario = votoDTO.comentario;
                voto.voto = votoDTO.voto;
                voto.fecha = DateTime.UtcNow;

                contexto.SaveChanges();

                var temp = contexto.Tickets.Include(x => x.Tipo_Ticket)
                    .Where(x => x.Id == voto.IdTicket).First().Tipo_Ticket.tipo;


                if (temp == "Modelo_Paralelo")
                {
                    var veredicto = VerificarAprobacionTicketParalelo(Guid.Parse(votoDTO.IdTicket));
                }
                if (temp == "Modelo_Jerarquico")
                {
                    var veredicto = VerificarAprobacionTicketJerarquico(Guid.Parse(votoDTO.IdTicket));

                }

                contexto.SaveChanges();
                response.Data = votoDTO;

            }
            catch (ExceptionsControl ex)
            {
                response.Exception = ex.Mensaje;
                response.Success = false;

            }

            return response;
        }

        private void ValidarDatosEntradaVotos(Votos_TicketDTOCreate votosDTO)
        {
            try
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
                var ticket = contexto.Tickets.Include(x => x.Tipo_Ticket).Where(x => x.Id == Guid.Parse(votosDTO.IdTicket)).First();

                if (ticket == null)
                {
                    throw new ExceptionsControl(ErroresVotos.ERROR_TICKET_DESC);
                }
                if (contexto.Usuarios.Find(Guid.Parse(votosDTO.IdUsuario)) == null)
                {
                    throw new ExceptionsControl(ErroresVotos.ERROR_USUARIO_DESC);
                }
                var voto = contexto.Votos_Tickets.Where(x => x.IdTicket.ToString().ToUpper() == votosDTO.IdTicket &&
                     x.IdUsuario.ToString().ToUpper() == votosDTO.IdUsuario.ToUpper()).First();
                if (voto == null)
                {
                    throw new ExceptionsControl(ErroresVotos.VOTO_NO_PERMITIDO);
                }

                if (ticket.Tipo_Ticket.tipo == "Modelo_Jerarquico")
                {
                    if (ticket.nro_cargo_actual != voto.Turno)
                    {
                        throw new ExceptionsControl(ErroresVotos.VOTACION_EXPIRADA);
                    }
                }
            }
            catch (FormatException ex)
            {
                throw new ExceptionsControl(ErroresVotos.FORMATO_NO_VALIDO, ex);
            }



        }

        public string VerificarAprobacionTicketParalelo(Guid Id)
        {

            try
            {
                var tipo_ticket = contexto.Tickets.Include(x => x.Tipo_Ticket)
                    .Where(x => x.Id == Id).First();

                var ticket = contexto.Tickets
                    .Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                    .Include(x => x.Emisor).ThenInclude(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Where(x => x.Id == Id).First();

                var votosfavor = contexto.Votos_Tickets.Where(x => x.IdTicket == Id
                && x.voto == "Aprobado").Count();
                if (votosfavor >= tipo_ticket.Tipo_Ticket.Minimo_Aprobado)
                {
                    CambiarEstado(ticket, "Aprobado");
                    var l = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();//.ForEach(x=>x.voto="Aprobado");
                    l.ForEach(x => x.voto = "Aprobado");
                    return "Aprobado";
                }

                var votoscontra = contexto.Votos_Tickets.Where(x => x.IdTicket == Id
                && x.voto == "Rechazado").Count();
                if (votoscontra >= tipo_ticket.Tipo_Ticket.Maximo_Rechazado)
                {
                    CambiarEstado(ticket, "Rechazado");
                    var l = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();//.ForEach(x => x.voto = "Rechazado");
                    l.ForEach(x => x.voto = "Rechazado");
                    return "Rechazado";
                }

                contexto.SaveChanges();
            }
            catch (ExceptionsControl ex)
            {
                return "Fallido";
            }

            return "Pendiente";
        }

        private bool CambiarEstado(Ticket ticket, string Estado)
        {
            try
            {
                ticket.Estado = contexto.Estados.Include(x => x.Estado_Padre).Include(x => x.Departamento).
                    Where(s => s.Estado_Padre.nombre == Estado &&
                    s.Departamento.Id == ticket.Emisor.Cargo.Departamento.Id)
                    .FirstOrDefault();
                var vticket = contexto.Tickets.Update(ticket);
                vticket.State = EntityState.Modified;

            }
            catch (ExceptionsControl ex)
            {
                return false;
            }
            return true;
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
                    var l = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();
                    l.ForEach(x => x.voto = "Aprobado");

                    //Ingreso siguiente ronda de votos
                    ticket.nro_cargo_actual++;
                    var fin = VotosSiguienteRonda(ticket, tipo_ticket);
                    if (fin)
                    {
                        CambiarEstado(ticket, "Aprobado");
                        contexto.SaveChanges();
                        return "Aprobado";
                    }
                    contexto.SaveChanges();
                    return "Pendiente";
                }

                //contar votos en contra
                var votoscontra = contexto.Votos_Tickets.Where(x => x.IdTicket == Id
                && x.voto == "Rechazado" && x.Turno == ticket.nro_cargo_actual).Count();
                if (votoscontra >= maximo_rechazado)
                {
                    //Cambiar Estado a los votos restantes
                    var l = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();
                    l.ForEach(x => x.voto = "Rechazado");

                    //Ingreso siguiente ronda de votos
                    CambiarEstado(ticket, "Rechazado");
                    contexto.SaveChanges();
                    //EnviarNotiicacion("Ticket Rechazado")
                    return "Rechazado";

                }

                contexto.SaveChanges();
            }
            catch (ExceptionsControl ex)
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

            var tipoCargos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Tipo_Cargo)
                    .ThenInclude(x => x.Cargos_Asociados)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id &&
                        x.OrdenAprobacion == ticket.nro_cargo_actual)
                    .OrderBy(x => x.OrdenAprobacion).First();


            var Cargos = tipoCargos.Tipo_Cargo.Cargos_Asociados.ToList()
                .Where(x => x.Departamento.Id == ticket.Emisor.Cargo.Departamento.Id).First();


            var ListaEmpleado = contexto.Empleados.Where(x => x.Cargo.Id == Cargos.Id).ToList();


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


            return false;
        }

    }
}
