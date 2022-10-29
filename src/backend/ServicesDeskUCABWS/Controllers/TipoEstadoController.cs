using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.Exceptions;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Models.DTO.TipoEstadoDTO;
using ServicesDeskUCABWS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("TipoEstado")]
    [ApiController]
    public class TipoEstadoController:ControllerBase
    {
        private readonly ITipoEstadoDAO _tipoEstado;
        private readonly IPlantillaNotificacionDAO _plantilla;
        private readonly IMapper _mapper;

        public TipoEstadoController(ITipoEstadoDAO tipoEstadoContext, IPlantillaNotificacionDAO plantilla, IMapper mapper)
        {
            _tipoEstado = tipoEstadoContext;
            _plantilla = plantilla;
            _mapper = mapper;
        }

        //GET: Controlador para consultar todas los tipos estados
        [HttpGet]
        [Route("Consulta/")]
        public ApplicationResponse<List<TipoEstadoSearchDTO>> ConsultaTipoEstadosCtrl()
        {
            var response = new ApplicationResponse<List<TipoEstadoSearchDTO>>();

            try
            {
                response.Data = _tipoEstado.ConsultaTipoEstados();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //GET: Controlador para consultar un tipo estado en especifico
        [HttpGet]
        [Route("Consulta/{id}")]
        public ActionResult<ApplicationResponse<TipoEstadoSearchDTO>> GetByGuidCtrl(Guid id)
        {
            var response = new ApplicationResponse<TipoEstadoSearchDTO>();

            try
            {
                response.Data = _tipoEstado.ConsultarTipoEstadoGUID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }

        //GET: Controlador para consultar una tipo estado por un título específico
        [HttpGet]
        [Route("Consulta/Titulo/{titulo}")]
        public ApplicationResponse<List<TipoEstadoSearchDTO>> GetByTituloCtrl(string titulo)
        {
            var response = new ApplicationResponse<List<TipoEstadoSearchDTO>>();
            try
            {
                response.Data = _tipoEstado.ConsultarTipoEstadoTitulo(titulo);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //POST: Controlador para crear tipo estado **
        [HttpPost]
        [Route("Registro/")]
        public ApplicationResponse<String> CrearTipoEstadoCtrl(TipoEstadoCreateDTO tipoEstadoDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var tipoEstado = new Tipo_Estado
                {
                    Id = Guid.NewGuid(),
                    nombre = tipoEstadoDTO.nombre,
                    descripcion = tipoEstadoDTO.descripcion,
                    Etiqueta = tipoEstadoDTO.Etiqueta,
                };
                response.Data = _tipoEstado.RegistroTipoEstado(tipoEstado).ToString();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //DELETE: Controlador para eliminar tipo estado
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public ApplicationResponse<String> EliminarTipoEstadoCtrl(Guid id)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                var plantillaTipoTicket = _plantilla.ConsultarPlantillaTipoEstadoID(id);
                var plantillaUpdate = _mapper.Map<PlantillaNotificacionUpdateDTO>(plantillaTipoTicket);
                plantillaUpdate.TipoEstadoId = null;
                _plantilla.ActualizarPlantilla(plantillaUpdate);
                response.Data = _tipoEstado.EliminarTipoEstado(id).ToString();
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
