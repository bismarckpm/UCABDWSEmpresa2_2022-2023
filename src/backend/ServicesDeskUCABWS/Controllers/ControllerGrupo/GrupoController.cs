using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperGrupo;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;

namespace ServicesDeskUCABWS.Controllers.ControllerGrupo
{
    [Route("Grupo")]
    [ApiController]
    public class GrupoController : ControllerBase
    {

        private readonly IGrupoDAO _grupoDAO;

		//Constructor
		public GrupoController(IGrupoDAO grupoDAO)
		{
			_grupoDAO = grupoDAO;
		}

        //Crear Departamento
        [HttpPost]
        [Route("CrearGrupo/")]
        public ApplicationResponse<GrupoDto> CrearGrupo([FromBody] GrupoDto dto1)
        {
			var response = new ApplicationResponse<GrupoDto>();
			try
            {
                response.Data = _grupoDAO.AgregarGrupoDao(GrupoMapper.MapperDTOToEntity(dto1));

            }
			catch (ExceptionsControl ex)
			{
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

        //Consultar Grupo por ID
        [HttpGet]
        [Route("ConsultarGrupoPorID/{id}")]
        public ApplicationResponse<GrupoDto> ConsultarPorID([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<GrupoDto>();
			try
            {
                response.Data = _grupoDAO.ConsultarPorIdDao(id);

            }
            catch (ExceptionsControl ex)
            {
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
            return response;
        }

        //Eliminar Grupo
        [HttpDelete]
        [Route("EliminarGrupo/{id}")]
        public ApplicationResponse<GrupoDto> EliminarGrupo([FromRoute] Guid id)
        {
			var response = new ApplicationResponse<GrupoDto>();
			try
			{
				response.Data = _grupoDAO.EliminarGrupoDao(id);
			}
			catch (ExceptionsControl ex)
			{
				response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

        
        //Actualizar Grupo
        [HttpPut]
        [Route("ActualizarGrupo/")]
        public ApplicationResponse<GrupoDto_Update> ActualizarGrupo([FromBody] GrupoDto_Update grupo)
        {
            var response = new ApplicationResponse<GrupoDto_Update>();
            try
            {
                response.Data = _grupoDAO.ModificarGrupoDao(GrupoMapper.MapperDTOToEntityUpdate(grupo));

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //Mostrar todos los grupos que no están eliminados
        [HttpGet("ConsultarGrupoNoEliminado/")]
		public ApplicationResponse<List<GrupoDto>> ListaGrupoNoEliminado()
		{
			var response = new ApplicationResponse<List<GrupoDto>>();
			try
			{
				response.Data = _grupoDAO.ConsultarGrupoNoEliminado();
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
                response.Data = _grupoDAO.AsignarGrupoToDepartamento(id, idDepartamentos);
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
                response.Data = _grupoDAO.EditarRelacion(id, idDepartamentos);
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
                response.Data = _grupoDAO.GetByIdDepartamento(idGrupo);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("ConsultarPorNombreGrupo/{nombreGrupo}")]
        public ApplicationResponse<GrupoDto> ConsultarNombreGrupo(string nombreGrupo)
        {
            var response = new ApplicationResponse<GrupoDto>();
            try
            {
                response.Data = _grupoDAO.buscarGrupoNombre(nombreGrupo);
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
