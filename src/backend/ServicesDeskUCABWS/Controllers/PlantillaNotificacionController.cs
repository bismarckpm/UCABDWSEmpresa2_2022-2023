using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("PlantillaNotificacion")]
    [ApiController]
    public class PlantillaNotificacionController:ControllerBase
    {
        private readonly IPlantillaNotificacion _plantilla;

        public PlantillaNotificacionController(IPlantillaNotificacion plantilla)
        {
            _plantilla = plantilla; 
        }

        //GET: Controlador para consultar todas las plantillas
        [HttpGet]
        [Route("Consulta/")]
        public ApplicationResponse<List<PlantillaNotificacionDTO>> ConsultaPlantillasCtrl()
        {
            var response = new ApplicationResponse<List<PlantillaNotificacionDTO>>();

            try
            {
                response.Data = _plantilla.ConsultaPlantillas();
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
        public ApplicationResponse<PlantillaNotificacionDTO> GetByGuidCtrl(Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();

            try
            {
                response.Data = _plantilla.ConsultarPlantillaGUID(id);
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
        public ApplicationResponse<PlantillaNotificacionDTO> GetByTituloCtrl(string titulo)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();
            try
            {
                response.Data = _plantilla.ConsultarPlantillaTitulo(titulo);
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
        public ApplicationResponse<PlantillaNotificacionDTO> GetByTipoEstadoIdCtrl(Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();
            try
            {
                response.Data = _plantilla.ConsultarPlantillaTipoEstadoID(id);
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
        public ApplicationResponse<PlantillaNotificacionDTO> GetByTipoEstadoCtrl(string tipo_Estado)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTO>();
            try
            {
                response.Data = _plantilla.ConsultarPlantillaTipoEstadoTitulo(tipo_Estado);
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
        public ApplicationResponse<PlantillaNotificacionDTOCreate> CrearPlantillaCtrl(PlantillaNotificacionDTOCreate plantillaDTO)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTOCreate>();
            try
            {
                var resultService = _plantilla.RegistroPlantilla(plantillaDTO);
                response.Data = resultService;
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
        public ApplicationResponse<PlantillaNotificacionDTOCreate> ActualizarPlantillaCtrl( [FromBody] PlantillaNotificacionDTOCreate plantillaDTO, [FromRoute] Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTOCreate>();
            try
            {
                var resultService = _plantilla.ActualizarPlantilla(plantillaDTO, id);
                response.Data = resultService;
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
        public ApplicationResponse<PlantillaNotificacionDTOCreate> EliminarPlantillaCtrl(Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionDTOCreate>();
            try
            {
                var resultService = _plantilla.EliminarPlantilla(id);
                response.Data = resultService;
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
