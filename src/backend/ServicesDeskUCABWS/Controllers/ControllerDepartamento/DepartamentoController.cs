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


        /// <summary>
        /// Constructor.
        /// Inicialización de variables.
        /// </summary>
        /// <param name="departamentoDAO">Objeto de la interfaz de IDepartamentoDAO.</param>
        public DepartamentoController(IDepartamentoDAO departamentoDAO)
        {
            _departamentoDAO = departamentoDAO;

        }


        /// <summary>
        /// Método que recibe la petición Http,
        /// se pasa en el body del archivo Json los atributos del objeto Departamento.
        /// </summary>
        /// <param name="departamento">Objeto de tipo DepartamentoDto.</param>
        /// <returns>Devuelve un AplicationResponse que contien Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo DepartamentoDto.</returns>
        
        [HttpPost]
        [Route("CrearDepartamento/")]
        public ApplicationResponse<DepartamentoDto> CrearDepartamento([FromBody] DepartamentoDto departamento)
        {
            var response = new ApplicationResponse<DepartamentoDto>();
            try
            {
                response.Data = _departamentoDAO.AgregarDepartamentoDAO(DepartamentoMapper.MapperDTOToEntity(departamento));


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
        /// Método que consulta todos los departamentos.
        /// </summary>
        /// <returns>Devuelve un AplicationResponse que contiene Acuse de recibo,
        /// aceptación o rechazo y una lista de objetos de tipo DepartamentoDto.</returns>
        
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

        /// <summary>
        /// Método que recibe la petición Http,
        /// pasa por URL/URI los atributos del objeto Departamento.
        /// </summary>
        /// <param name="id">Identificador de Departamento.</param>
        /// <returns>Devuelve un AplicationResponse que contiene Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo DepartamentoDto.</returns>

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

        /// <summary>
        /// Método que recibe la petición Http,
        /// pasa por URL/URI los atributos del objeto Departamento.
        /// </summary>
        /// <param name="id">Identificador de un Departamento.</param>
        /// <returns>Devuelve un AplicationResponse que contiene Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo DepartamentoDto.</returns>
        
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

        /// <summary>
        /// Método que recibe la petición Http,
        /// se pasa en el body del archivo Json los atributos del objeto Departamento.
        /// </summary>
        /// <param name="departamento">Objeto de tipo DepartamentoDto_Update.</param>
        /// <returns>Devuelve un AplicationResponse que contiene Acuse de recibo,
        /// aceptación o rechazo y un objeto de tipo DepartamentoDto_Update.</returns>

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

        /// <summary>
        /// Método que consulta todos los departamentos no asociados a un grupo.
        /// </summary>
        /// <returns>Devuelve un AplicationResponse que contiene Acuse de recibo,
        /// aceptación o rechazo y una lista de objetos de tipo DepartamentoDto.</returns>

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

        /// <summary>
        /// Método que consulta todos los departamentos no eliminados (Con el campo fecha_eliminacion = null).
        /// </summary>
        /// <returns>Devuelve un AplicationResponse que contiene Acuse de recibo,
        /// aceptación o rechazo y una lista de objetos de tipo DepartamentoDto.</returns>

        [HttpGet]
        [Route("ConsultarDepartamentoNoEliminado/")]
        public ApplicationResponse<List<DepartamentoDto>> ListaDepartamentonoEliminado()
        {

            var response = new ApplicationResponse<List<DepartamentoDto>>();
            try
            {
                response.Data = _departamentoDAO.DepartamentosNoEliminados();
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
        [Route("ConsultarDepartamentoCargo/")]
        public ApplicationResponse<List<DepartamentoCargoDTO>> ListaDepartamentonoCargo()
        {

            var response = new ApplicationResponse<List<DepartamentoCargoDTO>>();
            try
            {
                response.Data = _departamentoDAO.ConsultarDepartamentoCargo();
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

