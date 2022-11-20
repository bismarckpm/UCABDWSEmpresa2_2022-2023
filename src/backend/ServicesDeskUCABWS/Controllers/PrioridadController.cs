using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("Prioridad"), ApiController]
    public class PrioridadController : ControllerBase
    {

        private readonly IPrioridadDAO _prioridadDAO;
        private readonly IMapper _mapper;
        public PrioridadController(IPrioridadDAO prioridadDAO, IMapper mapper)
        {
            _prioridadDAO=prioridadDAO;
            _mapper=mapper;
        }

        [HttpPost, Route("Guardar")]
        public ApplicationResponse<string> crearPrioridadCtrl([FromBody]PrioridadDTO prioridadDTO)
        {
            var respuesta = new ApplicationResponse<String>();
            try
            {
                respuesta.Data = _prioridadDAO.CrearPrioridad(prioridadDTO);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }


        [HttpGet, Route("Lista")]
        public ApplicationResponse<List<PrioridadDTO>> ObtenerPrioridadesCtrl()
        {
            var respuesta = new ApplicationResponse<List<PrioridadDTO>>();
            try
            {
                respuesta.Data = _prioridadDAO.ObtenerPrioridades();
                return respuesta;
            } 
            catch (System.IO.IOException ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                respuesta.Exception = ex.InnerException.ToString();

                return respuesta;
            }
        }

        [HttpGet, Route("Lista/{Nombre}")]
        public ActionResult<ApplicationResponse<PrioridadDTO>> ObtenerPrioridadPorNombreCtrl(string nombre)
        {
            var respuesta = new ApplicationResponse<PrioridadDTO>();
            try
            {
                respuesta.Data = _prioridadDAO.ObtenerPrioridadPorNombre(nombre);
                return respuesta;
            }
            catch (System.IO.IOException ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                respuesta.Exception = ex.InnerException.ToString();

                return respuesta;
            }
        }

        [HttpGet, Route("Obtener/{PrioridadID}")]
        public ApplicationResponse<PrioridadDTO> ObtenerPrioridad(string PrioridadID)
        {
            var respuesta = new ApplicationResponse<PrioridadDTO>();
            try
            {
                respuesta.Data = _prioridadDAO.ObtenerPrioridad(new Guid(PrioridadID));
                return respuesta;
            }
            catch (System.IO.IOException ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                respuesta.Exception = ex.InnerException.ToString();

                return respuesta;
            }
        }

        [HttpPut, Route("Editar")]
        public ApplicationResponse<String> ModificarPrioridadEstadoPorNombreCtrl([FromBody] PrioridadDTO prioridadDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                response.Data = _prioridadDAO.ModificarPrioridad(prioridadDTO);
                response.Success = true;
                response.Message = "Cambios Realizados con Éxito";
            }
            catch (System.IO.IOException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.InnerException.ToString();
            }
            return response;
        }
    }
}
