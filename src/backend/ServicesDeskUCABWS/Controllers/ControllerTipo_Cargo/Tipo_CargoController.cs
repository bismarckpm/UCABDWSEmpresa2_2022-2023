using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoCargo;
using ServicesDeskUCABWS.BussinesLogic.Response;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Controllers.ControllerTipo_Cargo
{
    [Route("Tipo_Cargo")]
    [ApiController]
    public class Tipo_CargoController : ControllerBase
    {
        private readonly ITipo_CargoDAO _tipo_cargoDAO;
        private readonly ILogger<Tipo_CargoController> _log;

        //Constructor
        public Tipo_CargoController(ITipo_CargoDAO tipo_CargoDAO, ILogger<Tipo_CargoController> log)
        {
            _tipo_cargoDAO = tipo_CargoDAO;
            _log = log;
        }

        //Crear Tipo de Cargo
        /*[HttpPost]
        [Route("CrearTipoCargo/")]
        public ActionResult<Tipo_CargoDto> CrearTipo_Cargo([FromBody] Tipo_CargoDto dto1)
        {
            try
            {
                var dao = _tipo_cargoDAO.AgregarTipo_CargoDAO(Tipo_CargoMapper.MapperDTOToEntity(dto1));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpGet]
        [Route("ConsultarTipoCargo/")]
        public ActionResult<List<Tipo_CargoDto>> ConsultarTipo_Cargos()
        {
            try
            {
                return _tipo_cargoDAO.ConsultarTipo_Cargos();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }



        /*[HttpGet]
        [Route("ConsultarTipo_CargoPorID/{id}")]
        public ApplicationResponse<Tipo_CargoDto> ConsultarPorID([FromRoute] Guid id)
        {

            var response = new ApplicationResponse<Tipo_CargoDto>();
            try
            {
                response.Data = _tipo_cargoDAO.ConsultarPorID(id);

            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/

        /*[HttpDelete]
        [Route("EliminarTipo_Cargo/{id}")]
        public ApplicationResponse<Tipo_CargoDto> EliminarTipo_Cargo([FromRoute] Guid id)
        {
            var response = new ApplicationResponse<Tipo_CargoDto>();
            try
            {
                response.Data = _tipo_cargoDAO.EliminarTipo_Cargo(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/

        /*[HttpPut]
        [Route("ActualizarTipo_Cargo/")]
        public ActionResult<Tipo_CargoDto_Update> ActualizarTipo([FromBody] Tipo_CargoDto_Update tipo)
        {
            try
            {
                return _tipo_cargoDAO.actualizarTipo_Cargo(Tipo_CargoMapper.MapperDTOToEntityModificar(tipo));
                //Cambiar parametros cuando realicemos frontend

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }*/
        //Mostrar todos los grupos que no están eliminados
        /*[HttpGet("ConsultarTipoCargoNoEliminado/")]
        public ApplicationResponse<List<Tipo_CargoDto>> ListaCargoNoEliminado()
        {
            var response = new ApplicationResponse<List<Tipo_CargoDto>>();
            try
            {
                response.Data = _tipo_cargoDAO.ConsultarGrupoNoEliminado();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }*/
        /*[HttpGet("ConsultarUltimoTipoCargoRegistrado/")]
        public ApplicationResponse<Tipo_CargoDto> UltimoTipoRegistradoDao()
        {
            var response = new ApplicationResponse<Tipo_CargoDto>();
            try
            {
                response.Data = _tipo_cargoDAO.UltimoTipoRegistradoDao();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }*/

        /*[HttpGet]
        [Route("ConsultarCargosGrupoE/")]
        public ActionResult<List<Tipo_CargoDTOSearch>> ConsultarCargo()
        {
            try
            {
                return _tipo_cargoDAO.ConsultarCargos();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }*/

    }
}
