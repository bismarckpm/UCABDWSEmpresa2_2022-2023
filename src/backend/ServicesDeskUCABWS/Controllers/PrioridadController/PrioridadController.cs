/*using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO;
using System;
using System.Collections.Generic;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;

namespace ServicesDeskUCABWS.Controllers.PrioridadController
{
    [Route("prioridad")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {

        private readonly IPrioridadDAO _prioridadDAO;
        private readonly IMapper _mapper;
        public PrioridadController(IPrioridadDAO prioridadDAO, IMapper mapper)
        {
            _prioridadDAO = prioridadDAO;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("crearPrioridad")]
        public ApplicationResponse<string> crearPrioridadCtrl([FromBody] PrioridadDTO prioridadDTO)
        {
            var respuesta = new ApplicationResponse<string>();
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
        public ApplicationResponse<string> modificarPrioridadEstadoPorNombreCtrl([FromBody] PrioridadDTO prioridadDTO)
        {
            var response = new ApplicationResponse<string>();
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
}*/
