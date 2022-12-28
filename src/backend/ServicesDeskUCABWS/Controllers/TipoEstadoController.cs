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
        private readonly ITipoEstado _tipoEstadoService;
        public TipoEstadoController(ITipoEstado tipoEstadoService)
        {
            _tipoEstadoService = tipoEstadoService;
        }

        //GET: Controlador para consultar todas los tipos estados
        [HttpGet]
        [Route("Consulta/")]
        public ApplicationResponse<List<TipoEstadoDTO>> ConsultaTipoEstadosCtrl()
        {
            var response = new ApplicationResponse<List<TipoEstadoDTO>>();

            try
            {
                response.Data = _tipoEstadoService.ConsultaTipoEstados();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //GET: Controlador para consultar todas los tipos estados habilitados
        [HttpGet]
        [Route("ConsultaHabilitado/")]
        public ApplicationResponse<List<TipoEstadoDTO>> ConsultaTipoEstadosHabilitadosCtrl()
        {
            var response = new ApplicationResponse<List<TipoEstadoDTO>>();

            try
            {
                response.Data = _tipoEstadoService.ConsultaTipoEstadosHabilitados();
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
                response.Data = _tipoEstadoService.ConsultarTipoEstadoGUID(id);
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
                response.Data = _tipoEstadoService.ConsultarTipoEstadoTitulo(titulo);
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
        public ApplicationResponse<TipoEstadoDTO> CrearTipoEstadoCtrl( TipoEstadoCreateDTO tipoEstadoDTO)
        {
            var response = new ApplicationResponse<TipoEstadoDTO>();
            try
            {
                response.Data = _tipoEstadoService.RegistroTipoEstado(tipoEstadoDTO); ;
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
                response.Data = _tipoEstadoService.ActualizarTipoEstado(tipoEstadoDTO, id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //UPDATE: Controlador para habilitar y deshabilitar tipo estado
        [HttpPut]
        [Route("HabilitarDeshabilitar/{id}")]
        public ApplicationResponse<String> HabilitarDeshabilitarTipoEstadoCtrl(Guid id)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                response.Data = _tipoEstadoService.HabilitarDeshabilitarTipoEstado(id).ToString();

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
