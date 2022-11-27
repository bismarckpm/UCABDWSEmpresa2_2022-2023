using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperDepartamento;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicesDeskUCABWS.Controllers.ControllerDepartamento
{
    [Route("Departamento")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoDAO _departamentoDAO;
        

        //Constructor
        public DepartamentoController(IDepartamentoDAO departamentoDAO)
        {
            _departamentoDAO = departamentoDAO;
            
        }


        //Crear Departamento
        [HttpPost]
        [Route("CrearDepartamento/")]
        public ApplicationResponse<DepartamentoDto> CrearDepartamento([FromBody] DepartamentoDto dto1)
        {
            var response = new ApplicationResponse<DepartamentoDto>();
            try
            {
                response.Data = _departamentoDAO.AgregarDepartamentoDAO(DepartamentoMapper.MapperDTOToEntity(dto1));


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
        [Route("ConsultarDepartamento/")]
        public ApplicationResponse<List<DepartamentoDto>> ConsultarDepartamentos()
        {
            var response = new ApplicationResponse<List<DepartamentoDto>>();

            try
            {
                response.Data = _departamentoDAO.ConsultarDepartamentos();
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
        [Route("ConsultarDepartamentoPorID/{id}")]
        public ApplicationResponse<DepartamentoDto> ConsultarPorID([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<DepartamentoDto>();
            try
            {
                response.Data = _departamentoDAO.ConsultarPorID(id);
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
        [Route("EliminarDepartamento/{id}")]
        public ApplicationResponse<DepartamentoDto> EliminarDepartamento([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<DepartamentoDto>();
            try
            {
                response.Data = _departamentoDAO.eliminarDepartamento(id);
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
        [Route("ActualizarDepartamento/")]
        public ApplicationResponse<DepartamentoDto_Update> ActualizarDepartamento([FromBody] DepartamentoDto_Update departamento)
        {
            var response = new ApplicationResponse<DepartamentoDto_Update>();
            try
            {
                response.Data = _departamentoDAO.ActualizarDepartamento(DepartamentoMapper.MapperDTOToEntityModificar(departamento));
                

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("ConsultarDepartamentosPorIdGrupo/{idGrupo}")]
        public ApplicationResponse<List<DepartamentoDto>> ListaDepartamentosGrupo(Guid idGrupo)
        {
            var response = new ApplicationResponse<List<DepartamentoDto>>();
            try
            {
                response.Data = _departamentoDAO.GetByIdDepartamento(idGrupo);
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
        [Route("AsignarGrupoToDepartamento/{id}")]
        public ApplicationResponse<List<string>> AsignarGrupoToDepartamento([FromRoute] Guid id, [FromBody] string idDepartamentos)
        {
			var response = new ApplicationResponse<List<string>>();
			try
            {
                response.Data =  _departamentoDAO.AsignarGrupoToDepartamento(id,idDepartamentos);
            }
            catch (ExceptionsControl ex)
            {
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
            return response;
        }

        [HttpGet("ConsultarDepartamentoNoAsociado/")]
        public ApplicationResponse<List<DepartamentoDto>> ListaDepartamentoNoAsociado()
        {
            var response = new ApplicationResponse<List<DepartamentoDto>>();
            try
            {
                response.Data = _departamentoDAO.NoAsociado();
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
		[Route("ConsultarDepartamentoNoEliminado/")]
		public ApplicationResponse<List<DepartamentoDto>> ListaDepartamentonoEliminado()
        {

            var response = new ApplicationResponse<List<DepartamentoDto>>();
            try
            {
                response.Data = _departamentoDAO.DeletedDepartamento();
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
		[Route("EditarRelacion/{id}")]
		public ApplicationResponse<List<string>> EditarRelacion([FromRoute] Guid id, [FromBody] string idDepartamentos)
		{
			var response = new ApplicationResponse<List<string>>();
			try
			{
				response.Data = _departamentoDAO.EditarRelacion(id, idDepartamentos);
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
