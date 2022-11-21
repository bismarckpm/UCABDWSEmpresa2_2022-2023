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
using ServicesDeskUCABWS.Exceptions;

namespace ServicesDeskUCABWS.Controllers.ControllerGrupo
{
    [Route("Grupo")]
    [ApiController]
    public class GrupoController : ControllerBase
    {

        private readonly IGrupoDAO _grupoDAO;
        private readonly ILogger<GrupoController> _log;

        //Constructor
        public GrupoController(IGrupoDAO grupoDAO, ILogger<GrupoController> log)
        {
            _grupoDAO = grupoDAO;
            _log = log;
        }

        //Crear Departamento
        [HttpPost]
        [Route("CrearGrupo/")]
        public ActionResult<GrupoDto> CrearGrupo([FromBody] GrupoDto dto1)
        {
            try
            {
                var dao = _grupoDAO.AgregarGrupoDao(GrupoMapper.MapperDTOToEntity(dto1));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //Consultar Grupo
        [HttpGet]
        [Route("ConsultarGrupo/")]
        public ActionResult<List<GrupoDto>> ConsultarGrupos()
        {
            try
            {
                return _grupoDAO.ConsultarGruposDao();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
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
        public ActionResult<GrupoDto_Update> ActualizarDepartamento([FromBody] GrupoDto_Update grupo)
        {
            try
            {
                return _grupoDAO.ModificarGrupoDao(GrupoMapper.MapperDTOToEntityModificar(grupo));
                //Cambiar parametros cuando realicemos frontend

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        //Mostrar todos los grupos que no están eliminados
		[HttpGet("ConsultarGrupoNoEliminado/")]
		public ApplicationResponse<List<GrupoDto>> ListaDepartamentoNoEliminado()
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

	}
}
