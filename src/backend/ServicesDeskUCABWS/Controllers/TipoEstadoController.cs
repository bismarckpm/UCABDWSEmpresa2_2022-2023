using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO;
using ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.Response;
using System;
using System.Collections.Generic;


namespace ServicesDeskUCABWS.Controllers
{
    [Route("TipoEstado")]
    [ApiController]
    public class TipoEstadoController:ControllerBase
    {
        private readonly ITipoEstado _tipoEstado;
        

        public TipoEstadoController(ITipoEstado tipoEstadoContext)
        {
            _tipoEstado = tipoEstadoContext;
            
        }

        //GET: Controlador para consultar todas los tipos estados
        [HttpGet]
        [Route("Consulta/")]
        public ApplicationResponse<List<TipoEstadoDTO>> ConsultaTipoEstadosCtrl()
        {
            var response = new ApplicationResponse<List<TipoEstadoDTO>>();

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
        public ActionResult<ApplicationResponse<TipoEstadoDTO>> GetByGuidCtrl(Guid id)
        {
            var response = new ApplicationResponse<TipoEstadoDTO>();

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
        public ApplicationResponse<TipoEstadoDTO> GetByTituloCtrl(string titulo)
        {
            var response = new ApplicationResponse<TipoEstadoDTO>();
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
        public ApplicationResponse<String> CrearTipoEstadoCtrl( TipoEstadoDTO tipoEstadoDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {


                response.Data = _tipoEstado.RegistroTipoEstado(tipoEstadoDTO).ToString();

                
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //PUT: Controlador para modificar tipo estado
        [HttpPut]
        [Route("Actualizar/{id}")]
        public ApplicationResponse<String> ActualizarTipoEstadoCtrl([FromBody]TipoEstadoDTO tipoEstadoDTO,[FromRoute] Guid id)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                response.Data = _tipoEstado.ActualizarTipoEstado(tipoEstadoDTO, id).ToString();
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
