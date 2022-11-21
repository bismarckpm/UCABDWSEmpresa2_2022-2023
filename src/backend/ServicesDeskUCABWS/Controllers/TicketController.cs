using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Net;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("Ticket"),ApiController]
    public class TicketController
    {
        private readonly ITicketDAO _ticketDAO;
        private readonly IMapper _mapper;
        public TicketController(IMapper mapper, ITicketDAO ticketDAO)
        {
            _mapper = mapper;
            _ticketDAO = ticketDAO;
        }

        [HttpPost, Route("Guardar")]
        public ApplicationResponse<string> crearTicketCtrl([FromBody] TicketNuevoDTO nuevoTicket)
        {
            var respuesta = new ApplicationResponse<String>();
            try
            {
                respuesta.Data = _ticketDAO.crearTicket(nuevoTicket);
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = ex.Message;
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }

        [HttpGet, Route("Obtener/{id}")]
        public ApplicationResponse<Ticket> obtenerTicketPorIdCtrl(string id)
        {
            var respuesta = new ApplicationResponse<Ticket>();
            try
            {
                respuesta.Data = _ticketDAO.obtenerTicketPorId(new Guid(id));
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }

        [HttpGet,Route("Lista/{departamentoId}/{opcion}")]
        public ApplicationResponse<List<Ticket>> obtenerTicketsPorEstadoYDepartamentoCtrl(string departamentoId, string opcion)
        {
            var respuesta = new ApplicationResponse<List<Ticket>>();
            try
            {
                respuesta.Data = _ticketDAO.obtenerTickets(new Guid(departamentoId), opcion);
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }

        [HttpPut, Route("anadirBitacora")]
        public ApplicationResponse<string> anadirALaBitacoraCtrl([FromBody] BitacoraTicketDTO tickets)
        {
            var respuesta = new ApplicationResponse<string>();
            try
            {
                _ticketDAO.anadirALaBitacora(tickets.ticketDTO);
                respuesta.Data = $"Bitacora del ticket{tickets.ticketDTO.Id} modificada";
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = "No se pudo añadir la bitacora al ticket";
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }

        [HttpPut, Route("crearFamiliaTicket")]
        public ApplicationResponse<string> crearFamiliaTicketCtrl([FromBody] TicketsParientesDTO ticketsParientes)
        {
            var respuesta = new ApplicationResponse<string>();
            try
            {
                respuesta.Data =  _ticketDAO.crearFamiliaTickets(ticketsParientes.ticketA, ticketsParientes.ticketB);
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = "No se pudo añadir la bitacora al ticket";
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }

        [HttpGet,Route("Familia/{id}")]
        public ApplicationResponse<List<Ticket>> obtenerFamiliaTicketCtrl(string id)
        {
            var respuesta = new ApplicationResponse<List<Ticket>>();
            try
            {
                respuesta.Data = _ticketDAO.obtenerFamiliaTickets(new Guid(id));
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }

        [HttpPut, Route("Merge")]
        public ApplicationResponse<string> mergeTicketsCtrl([FromBody] TicketsMerge ticketsMerge)
        {
            var respuesta = new ApplicationResponse<string>();
            try
            {
                respuesta.Data =  _ticketDAO.mergeTickets(ticketsMerge.ticketPrincipal, ticketsMerge.tickets);
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = "No se pudo añadir la bitacora al ticket";
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }


        [HttpPut, Route("Reenviar")]
        public ApplicationResponse<string> crearTicketHijoCtrl([FromBody] TicketPaterno ticketPaterno)
        {
            var respuesta = new ApplicationResponse<string>();
            try
            {
                respuesta.Data = _ticketDAO.crearTicketHijo(ticketPaterno.ticketPadre, ticketPaterno.ticketHijo);
                respuesta.Message = "Proceso Exitoso";
                respuesta.StatusCode = HttpStatusCode.OK;
                respuesta.Exception = null;
            }
            catch (Exception ex)
            {
                respuesta.Data = "No se pudo añadir la bitacora al ticket";
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }
    }
}
