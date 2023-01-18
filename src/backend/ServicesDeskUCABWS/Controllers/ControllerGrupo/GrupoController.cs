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

        /// <summary>
        /// Declaración de variables.
        /// </summary>

        private readonly IGrupoDAO _grupoDAO;

		/// <summary>
        /// Constructor.
        /// Inicialización de variables.
        /// </summary>
        /// <param name="grupoDAO">Objeto de la interfaz de IGrupoDAO.</param>
		public GrupoController(IGrupoDAO grupoDAO)
		{
			_grupoDAO = grupoDAO;
		}

        /// <summary>
        /// Método que recibe la petición Http,
        /// se pasa en el body del archivo Json los atributos del objeto Grupo.
        /// </summary>
        /// <param name="dto1">Objeto de tipo GrupoDto.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo GrupoDto.</returns>
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
			{response.Success = false;
				response.Message = ex.Mensaje;
				response.Exception = ex.Excepcion.ToString();
			}
			return response;
		}

        /// <summary>
        /// Método que recibe la petición Http,
        /// pasa por URL/URI los atributos del objeto Grupo.
        /// </summary>
        /// <param name="id">Identificador de Grupo.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo GrupoDto.</returns>
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

        /// <summary>
        /// Método que recibe la petición Http,
        /// pasa por URL/URI los atributos del objeto Grupo.
        /// </summary>
        /// <param name="id">Identificador de un Grupo.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo GrupoDto.</returns>
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


        /// <summary>
        /// Método que recibe la petición Http,
        /// se pasa en el body del archivo Json los atributos del objeto Grupo.
        /// </summary>
        /// <param name="grupo">Objeto de tipo GrupoDto_Update.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo GrupoDto_Update.</returns>
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

        /// <summary>
        /// Método que consulta todos los grupos activos.
        /// </summary>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y una lista de objetos de tipo GrupoDto.</returns>
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

        /// <summary>
        /// Método que recibe una petición Http por URL/URI y otra petición pasa por el body del archivo Json,
        /// para asociar departamentos a un grupo.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <param name="idDepartamentos">Lista de identificadores de departamentos.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y una lista de string.</returns>
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

        /// <summary>
        /// Método que recibe una petición por URL/URI y otra petición pasa por el body del archivo Json,
        /// para asociar departamentos a un grupo.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <param name="idDepartamentos">Lista de identificadores de departamentos.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y una lista de string.</returns>
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

        /// <summary>
        /// Método que recibe una petición Http por URL/URI y otra petición pasa por el body del archivo Json,
        /// para editar (agregar o eliminar) la relación entre departamentos y un grupo.
        /// </summary>
        /// <param name="idGrupo">Identificador de un grupo.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y una lista de objetos tipo DepartamentoDto.</returns>
        [HttpGet("ConsultarDepartamentosPorIdGrupo/{idGrupo}")]
        public ApplicationResponse<List<DepartamentoDto>> ListaDepartamentosGrupo([FromRoute] Guid idGrupo)
        {
            var response = new ApplicationResponse<List<DepartamentoDto>>();
            try
            {
                response.Data = _grupoDAO.DepartamentosAsociados(idGrupo);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        /// <summary>
        /// Método que recibe una petición Http por URL/URI el nombre de un grupo.
        /// </summary>
        /// <param name="nombreGrupo">Identificador de un grupo.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y un objeto tipo GrupoDto.</returns>
        [HttpGet("ConsultarPorNombreGrupo/{nombreGrupo}")]
        public ApplicationResponse<GrupoDto> ConsultarNombreGrupo([FromRoute] string nombreGrupo)
        {
            var response = new ApplicationResponse<GrupoDto>();
            try
            {
                response.Data = _grupoDAO.BuscarGrupoNombre(nombreGrupo);
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