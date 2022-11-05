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
    [Route("prioridad")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {

        private readonly IPrioridadDAO _prioridadDAO;
        private readonly IMapper _mapper;
        public PrioridadController(IPrioridadDAO prioridadDAO, IMapper mapper)
        {
            _prioridadDAO=prioridadDAO;
            _mapper=mapper;
        }

        [HttpPost]
        [Route("crearPrioridad")]
        public ApplicationResponse<string> crearPrioridadCtrl([FromBody]PrioridadDTO prioridadDTO)
        {
            var respuesta = new ApplicationResponse<String>();
            try
            {
                respuesta.Data = _prioridadDAO.crearPrioridad(prioridadDTO);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }


        [HttpGet]
        [Route("getprioridades")]
        public ApplicationResponse<List<PrioridadDTO>> obtenerPrioridadesCtrl()
        {
            var respuesta = new ApplicationResponse<List<PrioridadDTO>>();
            try
            {
                respuesta.Data = _prioridadDAO.obtenerPrioridades();
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

        [HttpGet]
        [Route("getprioridades/nombre/{nombre}")]
        public ActionResult<ApplicationResponse<PrioridadDTO>> obtenerPrioridadPorNombreCtrl(string nombre)
        {
            var respuesta = new ApplicationResponse<PrioridadDTO>();
            try
            {
                respuesta.Data = _prioridadDAO.obtenerPrioridadPorNombre(nombre);
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

        [HttpGet]
        [Route("getprioridad/estado/{estado}")]
        public ApplicationResponse<List<PrioridadDTO>> obtenerPrioridadesPorEstadoCtrl(string estado)
        {
            var respuesta = new ApplicationResponse<List<PrioridadDTO>>();
            try
            {
                respuesta.Data = _prioridadDAO.obtenerPrioridadesPorEstado(estado);
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

        [HttpPut]
        [Route("modificarprioridad")]
        public ApplicationResponse<String> modificarPrioridadEstadoPorNombreCtrl([FromBody] PrioridadDTO prioridadDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                response.Data = _prioridadDAO.modificarPrioridad(prioridadDTO);
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
