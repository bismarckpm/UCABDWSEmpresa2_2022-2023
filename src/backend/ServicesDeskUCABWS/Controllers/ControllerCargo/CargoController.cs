using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;

namespace ServicesDeskUCABWS.Controllers.ControllerCargo
{

    [Route("api/[controller]")]
    [ApiController]
    public class CargoController
    {
        private readonly DataContext _context;
        private readonly ICargoDAO _cargoDAO;
        private readonly IMapper _mapper;


        public CargoController(ICargoDAO cargoDAO)
        {
            _cargoDAO = cargoDAO;
        }

        [HttpGet]
        [Route("Consulta/{id}")]
        public ApplicationResponse<IEnumerable<CargoDTOUpdate>> ConsultarCargosCtrl(Guid id)
        {
            var response = new ApplicationResponse<IEnumerable<CargoDTOUpdate>>();

            try
            {
                response.Data = _cargoDAO.ConsultarCargosDepartamento(id);
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
        public ApplicationResponse<CargoDTOUpdate> EsitarCargoCtrl(CargoDTOUpdate estadoDTO)
        {
            var response = new ApplicationResponse<CargoDTOUpdate>();

            try
            {
                response.Data = _cargoDAO.ModificarCargo(estadoDTO);
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
        [Route("DeshabilitarCargo/{Id}")]
        public ApplicationResponse<CargoDTOUpdate> Deshabilitarcargo([FromRoute] Guid Id)
        {
            var response = new ApplicationResponse<CargoDTOUpdate>();

            try
            {
                response.Data = _cargoDAO.DeshabilitarCargo(Id);
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
        [Route("HabilitarCargo/{Id}")]
        public ApplicationResponse<CargoDTOUpdate> HabilitarEstado([FromRoute] Guid Id)
        {
            var response = new ApplicationResponse<CargoDTOUpdate>();

            try
            {
                response.Data = _cargoDAO.HabilitarCargo(Id);
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
