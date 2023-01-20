using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
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
        private readonly IMapper mapper;
        private readonly ITicketDAO iticket;
        private readonly INotificacion notificacion;

        public Votos_TicketService(IDataContext Context, ITicketDAO ticketDAO, IMapper Mapper, INotificacion Notificacion)
        {
            iticket = ticketDAO;
            contexto = Context;
            mapper = Mapper;
            notificacion = Notificacion;
        }

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

                string veredicto = ticket.Tipo_Ticket.VerificarVotacion(ticket,contexto,notificacion);

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

            var votoGeneral = mapper.Map<Votos_Ticket>(votosDTO);

            //Largo de Comentario
            ValidacionesVotos.LongitudComentario(votoGeneral);

            //Verificar si el estado es permitido
            ValidacionesVotos.VerificarEstadoVoto(votoGeneral);

            //Verificar si el ticket existe
            ValidacionesVotos.VerificarTicket(votoGeneral, contexto);

            //Verificar si el usuario existe
            ValidacionesVotos.VerificarUsuario(votoGeneral, contexto);

            //Verifica si el voto esta registrado en el sistema
            ValidacionesVotos.VerificarVoto(votoGeneral, contexto);

            //Verificar si el voto tiene el turno correcto
            ValidacionesVotos.VerificarTurno(votoGeneral, contexto);
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
