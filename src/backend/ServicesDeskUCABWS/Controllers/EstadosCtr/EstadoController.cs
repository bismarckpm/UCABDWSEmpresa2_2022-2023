
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Controllers.EstadosController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController
    {
        private readonly DataContext _context;
        private readonly IEstadoDAO _estadoDAO;
        private readonly IMapper _mapper;

        public EstadoController(IEstadoDAO estadoDAO)
        {
            _estadoDAO = estadoDAO;
        }

        [HttpGet]
        [Route("Consulta/{id}")]
        public ApplicationResponse<IEnumerable<EstadoDTOUpdate>> ConsultarEstadoCtrl(Guid id)
        {
            var response = new ApplicationResponse<IEnumerable<EstadoDTOUpdate>>();

            try
            {
                response.Data = _estadoDAO.ConsultarEstadosDepartamento(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }

        [HttpPut]
        [Route("Editar/")]
        public ApplicationResponse<EstadoDTOUpdate> EsitarEstadoCtrl(EstadoDTOUpdate estadoDTO)
        {
            var response = new ApplicationResponse<EstadoDTOUpdate>();

            try
            {
                response.Data = _estadoDAO.ModificarEstado(estadoDTO);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }

        [HttpGet]
        [Route("ConsultarEstadosTicket/{Id}")]
        public ApplicationResponse<List<EstadoDTOSearch>> ConsultarEstadoDepartamento(Guid Id)
        {
            var response = new ApplicationResponse<List<EstadoDTOSearch>>();

            try
            {
                response.Data = _estadoDAO.ConsultarEstadosDepartamentoTicket(Id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }
    }
}
