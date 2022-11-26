using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;
using System;
using System.Collections.Generic;
using static ServicesDeskUCABWS.BussinesLogic.Excepciones.PrioridadExcepciones;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("Prioridad"), ApiController]
    public class PrioridadController : ControllerBase
    {

        private readonly IPrioridadDAO _prioridadDAO;
        private readonly IMapper _mapper;
        public PrioridadController(IPrioridadDAO prioridadDAO, IMapper mapper)
        {
            _prioridadDAO = prioridadDAO;
            _mapper = mapper;
        }
        [HttpPost, Route("Guardar")]
        public ApplicationResponse<string> crearPrioridadCtrl([FromBody] PrioridadSolicitudDTO prioridadDTO)
        {
            var respuesta = new ApplicationResponse<String>();
            try
            {
                respuesta.Data = _prioridadDAO.CrearPrioridad(prioridadDTO);
                respuesta.Success = true;
                respuesta.Message = "Prioridad creada satisfactoriamente pibe";
            }catch (PrioridadNombreLongitudException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                //respuesta.Exception = ex.InnerException.ToString();
            }catch(PrioridadDescripcionLongitudException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                //respuesta.Exception = ex.InnerException.ToString();
            }catch (PrioridadEstadoException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                //respuesta.Exception = ex.InnerException.ToString();
            }catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                //respuesta.Exception = ex.InnerException.ToString();
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
                respuesta.Message = "Mano sí se pudo mano";
                respuesta.Success = true;
                //respuesta.Message = "Ahí están las prioridades, anulo mufa";
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Message = ex.Message;
                respuesta.Success = false;
                //respuesta.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }
        [HttpGet, Route("Lista/Habilitadas")]
        public ActionResult<ApplicationResponse<List<PrioridadDTO>>> ObtenerPrioridadesHabilitadas()
        {
            var respuesta = new ApplicationResponse<List<PrioridadDTO>>();
            try
            {
                respuesta.Data = _prioridadDAO.ObtenerPrioridades();
                respuesta.Success = true;
                respuesta.Message = "El var dice que estaba habilitado";
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        [HttpGet, Route("Obtener/{PrioridadID}")]
        public ApplicationResponse<PrioridadDTO> ObtenerPrioridad(string PrioridadID)
        {
            var respuesta = new ApplicationResponse<PrioridadDTO>();
            try
            {
                respuesta.Data = _prioridadDAO.ObtenerPrioridad(new Guid(PrioridadID));
                respuesta.Success = true;
                respuesta.Message = "El 11 de prioridades";
            }
            catch (PrioridadNoExisteException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                //response.Exception = ex.InnerException.ToString();
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
        [HttpPut, Route("Editar")]
        public ApplicationResponse<String> ModificarPrioridadEstadoPorNombreCtrl([FromBody] PrioridadDTO prioridadDTO)
        {
            var respuesta = new ApplicationResponse<String>();
            try
            {
                respuesta.Data = _prioridadDAO.ModificarPrioridad(prioridadDTO);
                respuesta.Success = true;
                respuesta.Message = "Entra el genio del futbol mundial";
            }
            catch(PrioridadNoExisteException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                //response.Exception = ex.InnerException.ToString();
            }
            catch(PrioridadNombreLongitudException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            catch (PrioridadDescripcionLongitudException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            catch (PrioridadEstadoException ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            catch (Exception ex)
            {
                respuesta.Data = null;
                respuesta.Success = false;
                respuesta.Message = ex.Message;
                //response.Exception = ex.InnerException.ToString();
            }
            return respuesta;
        }
    }
}
