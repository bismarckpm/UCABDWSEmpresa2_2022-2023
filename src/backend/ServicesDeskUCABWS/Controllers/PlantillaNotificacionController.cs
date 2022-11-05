using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO;
using ServicesDeskUCABWS.Response;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("PlantillaNotificacion")]
    [ApiController]
    public class PlantillaNotificacionController:ControllerBase
    {
        private readonly IPlantillaNotificacion _plantilla;
        private readonly IMapper _mapper;

        public PlantillaNotificacionController(IPlantillaNotificacion plantilla, IMapper mapper)
        {
            _plantilla = plantilla;
            _mapper = mapper;   
        }

        //GET: Controlador para consultar todas las plantillas
        [HttpGet]
        [Route("Consulta/")]
        public async Task<ApplicationResponse<List<PlantillaNotificacionDTO>>> ConsultaPlantillasCtrl()
        {
            var response = new ApplicationResponse<List<PlantillaNotificacionDTO>>();

            try
            {
                response.Data = await _plantilla.ConsultaPlantillas();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //GET: Controlador para consultar una plantilla notificacion en especifico
        [HttpGet]
        [Route("Consulta/{id}")]
        public async Task<ActionResult<ApplicationResponse<PlantillaNotificacionDTO>>> GetByGuidCtrl(Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();

            try
            {
                response.Data = await _plantilla.ConsultarPlantillaGUID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
            
        }

        //GET: Controlador para consultar una plantilla notificacion por un título específico
        [HttpGet]
        [Route("Consulta/Titulo/{titulo}")]
        public async Task<ApplicationResponse<PlantillaNotificacionDTO>> GetByTituloCtrl(string titulo)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();
            try
            {
                response.Data = await _plantilla.ConsultarPlantillaTitulo(titulo);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //GET: Controlador para consultar una plantilla notificacion por un tipo estado específico mediante su ID
        [HttpGet]
        [Route("Consulta/PlantillaTipoEstadoID/{id}")]
        public async Task<ApplicationResponse<PlantillaNotificacionDTO>> GetByTipoEstadoIdCtrl(Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();
            try
            {
                response.Data = await _plantilla.ConsultarPlantillaTipoEstadoID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //GET: Controlador para consultar una plantilla notificacion por un tipo estado específico mediante su nombre
        [HttpGet]
        [Route("Consulta/PlantillaTipoEstadoNombre/{tipo_Estado}")]
        public async Task<ApplicationResponse<PlantillaNotificacionDTO>> GetByTipoEstadoCtrl(string tipo_Estado)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();
            try
            {
                response.Data = await _plantilla.ConsultarPlantillaTipoEstadoTitulo(tipo_Estado);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //POST: Controlador para crear plantilla notificacion
        [HttpPost]
        [Route("Registro/")]
        public async Task<ApplicationResponse<String>> CrearPlantillaCtrl(PlantillaNotificacionDTOCreate plantillaDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var resultService = await _plantilla.RegistroPlantilla(plantillaDTO);
                response.Data = resultService.ToString();

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //PUT: Controlador para modificar plantilla notificacion
        [HttpPut]
        [Route("Actualizar/{id}")]
        public async Task<ApplicationResponse<String>> ActualizarPlantillaCtrl( [FromBody] PlantillaNotificacionDTOCreate plantillaDTO, [FromRoute] Guid id)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var resultService = await _plantilla.ActualizarPlantilla(plantillaDTO, id);
                response.Data = resultService.ToString();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //DELETE: Controlador para eliminar plantilla notificacion
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ApplicationResponse<String>> EliminarPlantillaCtrl(Guid id)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var resultService = await _plantilla.EliminarPlantilla(id);
                response.Data = resultService.ToString();
            }
            catch(ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}
