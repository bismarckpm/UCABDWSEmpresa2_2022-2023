using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
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
            return _ticketDAO.crearTicket(nuevoTicket);
        }

        [HttpGet, Route("Obtener/{id}")]
        public ApplicationResponse<TicketInfoCompletaDTO> obtenerTicketPorIdCtrl(string id)
        {
            return _ticketDAO.obtenerTicketPorId(new Guid(id));
        }

        // No esta listo
        [HttpGet,Route("Lista/{departamentoId}/{opcion}")]
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamentoCtrl(string departamentoId, string opcion)
        {
            return _ticketDAO.obtenerTicketsPorEstadoYDepartamento(new Guid(departamentoId), opcion);
        }

        [HttpPut, Route("cambiarEstadoTicket/{ticketId}/{estadoId}")]
        public ApplicationResponse<string> cambiarEstadoTicketCtrl(string ticketId, string estadoId)
        {
            return _ticketDAO.cambiarEstadoTicket(new Guid(ticketId), new Guid(estadoId));
        }

        [HttpGet, Route("Bitacora/{ticketId}")]
        public ApplicationResponse<List<TicketBitacorasDTO>> obtenerBitacorasCtrl(string ticketId)
        {
            return _ticketDAO.obtenerBitacoras(new Guid(ticketId));
        }
        [HttpPut, Route("Merge")]
        public ApplicationResponse<string> mergeTicketsCtrl([FromBody] TicketsMergeDTO ticketsMerge)
        {
            return _ticketDAO.mergeTickets(ticketsMerge.ticketPrincipalId, ticketsMerge.ticketsSecundariosId);
        }
        // FALTA COLOCAR EL PADRE COMO ELIMINADO EN REENVIAR
        [HttpPost, Route("Reenviar")]
        public ApplicationResponse<string> reenviarTicket([FromBody] TicketReenviarDTO ticket)
        {
            return _ticketDAO.reenviarTicket(ticket);
        }
        
        [HttpGet,Route("Familia/{id}")]
        public ApplicationResponse<List<TicketInfoCompletaDTO>> obtenerFamiliaTicketCtrl(string id)
        {
            return _ticketDAO.obtenerFamiliaTicket(new Guid(id));
        }

        /*[HttpPut, Route("Reenviar")]
        public ApplicationResponse<string> reenviarTicketCtrl([FromBody] TicketReenvioDTO ticketInfo)
        {
            return _ticketDAO.reenviarTicket(ticketInfo.ticketPapaId, ticketInfo.solicitudTicket);
        }*/

        //DEVOLVER FAMILIA DE TICKET DADO EL ID DE UN TICKET(ticket_id)
    }
}