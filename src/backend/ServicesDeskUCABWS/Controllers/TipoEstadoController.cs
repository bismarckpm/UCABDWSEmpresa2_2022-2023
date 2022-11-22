using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public ApplicationResponse<TipoEstadoDTO> GetByGuidCtrl(Guid id)
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

        //POST: Controlador para crear tipo estado
        [HttpPost]
        [Route("Registro/")]
        public ApplicationResponse<TipoEstadoCreateDTO> CrearTipoEstadoCtrl( TipoEstadoCreateDTO tipoEstadoDTO)
        {
            var response = new ApplicationResponse<TipoEstadoCreateDTO>();
            try
            {
                var resultSevice = _tipoEstado.RegistroTipoEstado(tipoEstadoDTO);
                response.Data = resultSevice;
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
        public ApplicationResponse<TipoEstadoDTO> ActualizarTipoEstadoCtrl([FromBody] TipoEstadoUpdateDTO tipoEstadoDTO,[FromRoute] Guid id)
        {
            var response = new ApplicationResponse<TipoEstadoDTO>();
            try
            {
                var resultSevice = _tipoEstado.ActualizarTipoEstado(tipoEstadoDTO, id);
                response.Data = resultSevice;
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
        public ApplicationResponse<TipoEstadoCreateDTO> EliminarTipoEstadoCtrl(Guid id)
        {
            var response = new ApplicationResponse<TipoEstadoCreateDTO>();
            try
            {
                var resultSevice = _tipoEstado.EliminarTipoEstado(id);
                response.Data = resultSevice;
                      
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
