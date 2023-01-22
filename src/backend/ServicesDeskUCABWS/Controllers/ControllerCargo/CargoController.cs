using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperCargo;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;

namespace ServicesDeskUCABWS.Controllers.ControllerCargo
{
    [Route("Cargo")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICargoDAO _cargoDAO;
        private readonly IMapper _mapper;
        
        //Constructor
        public CargoController(ICargoDAO cargoDAO)
        {
            _cargoDAO = cargoDAO;            
        }

        //Crear Cargo
        [HttpPost]
        [Route("CrearCargo/")]
        public ApplicationResponse<CargoDTOCreate> AgregarCargoDAO([FromBody] CargoDTOCreate dto1)
        {
            var response = new ApplicationResponse<CargoDTOCreate>();
            try
            {
                response.Data = _cargoDAO.AgregarCargoDAO(dto1);


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
        [Route("ConsultarCargos/")]
        public ApplicationResponse<List<CargoDto>> ConsultarCargos()
        {
            var response = new ApplicationResponse<List<CargoDto>>();

            try
            {
                response.Data = _cargoDAO.ConsultarCargos();
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
        [Route("ConsultarPorID/{id}")]
        public ApplicationResponse<CargoDto> ConsultarPorID([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<CargoDto>();
            try
            {
                response.Data = _cargoDAO.ConsultarPorID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
        [HttpDelete]
        /*[Route("eliminarCargo/{id}")]
        public ApplicationResponse<CargoDto> eliminarCargo([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<CargoDto>();
            try
            {
                response.Data = _cargoDAO.eliminarCargo(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/

        [HttpPut]
        [Route("ActualizarCargo/")]
        public ApplicationResponse<CargoDto_Update> ActualizarCargo([FromBody] CargoDto_Update cargo)
        {
            var response = new ApplicationResponse<CargoDto_Update>();
            try
            {
                response.Data = _cargoDAO.ActualizarCargo(CargoMapper.MapperDTOToEntityModificar(cargo));
                
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }
        /*
        [HttpPut]
        [Route("AsignarTipoCargotoCargo/{id}")]
        public ApplicationResponse<List<string>> AsignarTipoCargotoCargo([FromRoute] Guid id, [FromBody] string idCargos)
        {
            var response = new ApplicationResponse<List<string>>();

            try
            {
                response.Data = _cargoDAO.AsignarTipoCargotoCargo(id,idCargos);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/
        /*
        [HttpGet("ConsultarCargoNoAsociado/")]
        public ApplicationResponse<List<CargoDto>> ListaCargoNoAsociado()
        {
            var response = new ApplicationResponse<List<CargoDto>>();
            try
            {
                response.Data = _cargoDAO.NoAsociado();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }*/
        /*
        [HttpGet]
        [Route("ConsultarCargoNoEliminado/")]
        public ApplicationResponse<List<CargoDto>> ListaCargoEliminado()
        {
            var response = new ApplicationResponse<CargoDTOUpdate>();

            var response = new ApplicationResponse<List<CargoDto>>();
            try
            {
                response.Data = _cargoDAO.DeletedCargo();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;


        }*/
        /*[HttpGet("ConsultarCargoPorIdTipoCargo/{idTipo}")]
        public ApplicationResponse<List<CargoDto>> ListaCargosTipoCargo(Guid idTipo)
        {
            var response = new ApplicationResponse<List<CargoDto>>();
            try
            {
                response.Data = _cargoDAO.GetByIdCargo(idTipo);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/

        [HttpGet("ConsultarCargoPorDepartamento/{id}")]
        public ApplicationResponse<List<CargoDTOUpdate>> ConsultarCargosPorDepartamento([FromRoute]Guid id)
        {
            var response = new ApplicationResponse<List<CargoDTOUpdate>>();
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

        [HttpGet("ConsultarTodosCargoPorDepartamento/{id}")]
        public ApplicationResponse<List<CargoDTOUpdate>> ConsultarTodosCargosPorDepartamento([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<List<CargoDTOUpdate>>();
            try
            {
                response.Data = _cargoDAO.ConsultarCargosDepartamentoTodos(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }


        [HttpPut("Editar/")]
        public ApplicationResponse<CargoDTOUpdate> EditarCargo(CargoDTOUpdate DTO)
        {
            var response = new ApplicationResponse<CargoDTOUpdate>();
            try
            {
                response.Data = _cargoDAO.ModificarCargo(DTO);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPut("DeshabilitarCargo/{id}")]
        public ApplicationResponse<CargoDTOUpdate> DeshabilitarCargo([FromRoute]Guid id)
        {
            var response = new ApplicationResponse<CargoDTOUpdate>();
            try
            {
                response.Data = _cargoDAO.DeshabilitarCargo(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPut("HabilitarCargo/{id}")]
        public ApplicationResponse<CargoDTOUpdate> HabilitarCargo([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<CargoDTOUpdate>();
            try
            {
                response.Data = _cargoDAO.HabilitarCargo(id);
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