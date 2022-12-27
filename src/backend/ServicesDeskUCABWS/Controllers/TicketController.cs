using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
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

        [HttpGet,Route("Lista/{departamentoId}/{opcion}")]
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamentoCtrl(string departamentoId, string opcion)
        {
            return _ticketDAO.obtenerTicketsPorEstadoYDepartamento(new Guid(departamentoId), opcion);
        }

        [HttpPut, Route("CambiarEstado")]
        public ApplicationResponse<string> cambiarEstadoTicketCtrl([FromBody] ActualizarDTO actualizarDTO)
        {
            return _ticketDAO.cambiarEstadoTicket(new Guid(actualizarDTO.ticketId), new Guid(actualizarDTO.estadoId));
        }

        [HttpGet, Route("Bitacora/{ticketId}")]
        public ApplicationResponse<List<TicketBitacorasDTO>> obtenerBitacorasCtrl(string ticketId)
        {
            return _ticketDAO.obtenerBitacoras(new Guid(ticketId));
        }

        [HttpPost, Route("Merge")]
        public ApplicationResponse<string> mergeTicketsCtrl([FromBody] TicketsMergeDTO ticketsMerge)
        {
            return _ticketDAO.mergeTickets(ticketsMerge.ticketPrincipalId, ticketsMerge.ticketsSecundariosId);
        }

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
        [HttpPut, Route("Eliminar/{id}")]
        public ApplicationResponse<string> eliminarTicket(string id)
        {
            return _ticketDAO.eliminarTicket(new Guid(id));
        }

        [HttpGet, Route("ObtenerDepartamentos/{id}")]
        public ApplicationResponse<List<DepartamentoSearchDTO>> obtenerDepartamentos(string id)
        {
            return _ticketDAO.buscarDepartamentos(new Guid(id));
        }

        [HttpGet, Route("ObtenerDepartamentoEmpleado/{idEmpleado}")]
        public ApplicationResponse<DepartamentoSearchDTO> obtenerDepartamentoEmpleado(string idEmpleado)
        {
            return _ticketDAO.buscarDepartamentoEmpleado(new Guid(idEmpleado));
        }

        [HttpGet, Route("ObtenerTipoTickets/{idDepartamento}")]
        public ApplicationResponse<List<Tipo_TicketDTOSearch>> obtenerTipoTicketPorDepartamento(string idDepartamento)
        {
            return _ticketDAO.buscarTipoTickets(new Guid(idDepartamento));
        }
        
        [HttpGet, Route("ObtenerTiposTickets/")]
        public ApplicationResponse<List<Tipo_Ticket>> obtenerTiposTicketsPorDepartamento()
        {
            return _ticketDAO.buscarTiposTickets();
        }

        [HttpGet, Route("ObtenerEstadosPorDepartamento/{idDepartamento}")]
        public ApplicationResponse<List<Estado>> obtenerEstadosPorDepartamento(string idDepartamento)
        {
            return _ticketDAO.buscarEstadosPorDepartamento(new Guid(idDepartamento));
        }

        [HttpPost, Route("AdquirirTicket/")]
        public ApplicationResponse<string> adquirirTicketCtrl([FromBody] TicketTomarDTO ticketPropio)
        {
            return _ticketDAO.adquirirTicket(ticketPropio);
        }
        [HttpGet, Route("ObtenerTicketsPropios/{idEmpleado}")]
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPropiosCtrl(string idEmpleado)
        {   
            return _ticketDAO.obtenerTicketsPropios(new Guid(idEmpleado));
        }
    }
}