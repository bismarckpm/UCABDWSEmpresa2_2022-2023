using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO;
using ServicesDeskUCABWS.Response;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Entities;

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
        public ApplicationResponse<List<PlantillaNotificacionSearchDTO>> ConsultaPlantillasCtrl()
        {
            var response = new ApplicationResponse<List<PlantillaNotificacionSearchDTO>>();

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
        public ActionResult<ApplicationResponse<PlantillaNotificacionSearchDTO>> GetByGuidCtrl(Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionSearchDTO>();

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
        public ApplicationResponse<List<PlantillaNotificacionSearchDTO>> GetByTituloCtrl(string titulo)
        {
            var response = new ApplicationResponse<List<PlantillaNotificacionSearchDTO>>();
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
        public ApplicationResponse<PlantillaNotificacionSearchDTO> GetByTipoEstadoIdCtrl(Guid id)
        {
            var response = new ApplicationResponse<PlantillaNotificacionSearchDTO>();
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
        public ApplicationResponse<List<PlantillaNotificacionSearchDTO>> GetByTipoEstadoCtrl(string tipo_Estado)
        {
            var response = new ApplicationResponse<List<PlantillaNotificacionSearchDTO>>();
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
        public ApplicationResponse<String> CrearPlantillaCtrl(PlantillaNotificacionDTOCreate plantillaDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var plantilla = new PlantillaNotificacion
                {
                    Id = Guid.NewGuid(),
                    Titulo = plantillaDTO.Titulo,
                    Descripcion = plantillaDTO.Descripcion,
                    TipoEstadoId = plantillaDTO.TipoEstadoId
                };
                response.Data = _plantilla.RegistroPlantilla(plantilla).ToString();
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
        public ApplicationResponse<String> ActualizarPlantillaCtrl(PlantillaNotificacionUpdateDTO plantillaDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                response.Data = _plantilla.ActualizarPlantilla(plantillaDTO).ToString();                
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
        public ApplicationResponse<String> EliminarPlantillaCtrl(Guid id)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                response.Data = _plantilla.EliminarPlantilla(id).ToString();
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
