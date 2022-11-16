using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
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
        [HttpPost]
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

        [HttpGet]
        [Route("ConsultarTipo_CargoPorID/{id}")]
        public ActionResult<Tipo_CargoDto> ConsultarPorID([FromRoute] Guid id)
        {
            try
            {
                return _tipo_cargoDAO.ConsultarPorID(id);
            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        [HttpDelete]
        [Route("EliminarTipo_Cargo/{id}")]
        public ActionResult<Tipo_CargoDto> EliminarTipo_Cargo([FromRoute] Guid id)
        {
            try
            {
                return _tipo_cargoDAO.eliminarTipo_Cargo(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpPut]
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
        }

    }
}
