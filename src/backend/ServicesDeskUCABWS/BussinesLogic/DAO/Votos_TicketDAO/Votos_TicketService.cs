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
        private readonly ITicketDAO iticket;

        public Votos_TicketService(IDataContext Context, ITicketDAO ticketDAO)
        {
            iticket = ticketDAO;
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

                var ticket = ConsultarDatosTicket(Guid.Parse(votoDTO.IdTicket));

                var voto = ActualizarVoto(ticket,votoDTO);

                string veredicto = ticket.Tipo_Ticket.VerificarVotacion(ticket,contexto);

                contexto.DbContext.Update(ticket);
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

        public Ticket ConsultarDatosTicket(Guid idTicket)
        {
            return contexto.Tickets
                    .Include(x => x.Departamento_Destino).ThenInclude(x => x.grupo)
                    .Include(x => x.Prioridad)
                    .Include(x => x.Votos_Ticket)
                    .Include(x => x.Tipo_Ticket).ThenInclude(x => x.Flujo_Aprobacion)
                    .Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                    .Include(x => x.Emisor).ThenInclude(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Include(x => x.Bitacora_Tickets)
                    .Where(x => x.Id == idTicket).FirstOrDefault();
        }

        private Votos_Ticket ActualizarVoto(Ticket ticket, Votos_TicketDTOCreate votoDTO)
        {
            var voto = ticket.Votos_Ticket.Where(x => x.IdUsuario == Guid.Parse(votoDTO.IdUsuario)).FirstOrDefault();
            voto.comentario = votoDTO.comentario;
            voto.voto = votoDTO.voto;
            voto.fecha = DateTime.UtcNow;
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
                    .Where(x => x.IdUsuario == id && x.voto != "Pendiente" && x.fecha!=null).ToList();
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
