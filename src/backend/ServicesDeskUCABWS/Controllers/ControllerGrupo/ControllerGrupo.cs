using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mappers.MapperGrupo;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers.ControllerGrupo
{
    [Route("Grupo")]
    [ApiController]
    public class GrupoController : ControllerBase
    {

        private readonly IGrupoDAO _grupoDAO;
        private readonly ILogger<GrupoController> _log;

        //Constructor
        public GrupoController(IGrupoDAO grupoDAO, ILogger<GrupoController> log)
        {
            _grupoDAO = grupoDAO;
            _log = log;
        }

        //Crear Departamento
        [HttpPost]
        [Route("CrearGrupo/")]
        public ActionResult<GrupoDto> CrearGrupo([FromBody] GrupoDto dto1)
        {
            try
            {
                var dao = _grupoDAO.AgregarGrupoDao(GrupoMapper.MapperDTOToEntity(dto1));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //Consultar Grupo
        [HttpGet]
        [Route("ConsultarGrupo/")]
        public ActionResult<List<GrupoDto>> ConsultarGrupos()
        {
            try
            {
                return _grupoDAO.ConsultarGruposDao();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        //Agregar Grupo por ID
        [HttpGet]
        [Route("ConsultarGrupoPorID/{id}")]
        public ActionResult<GrupoDto> ConsultarPorID([FromRoute] Guid id)
        {
            try
            {
                return _grupoDAO.ConsultarPorIdDao(id);
            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        //Eliminar Grupo
        [HttpDelete]
        [Route("EliminarGrupo/{id}")]
        public ActionResult<GrupoDto> EliminarDepartamento([FromRoute] Guid id)
        {
            try
            {
                return _grupoDAO.EliminarGrupoDao(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        //Actualizar Grupo
        [HttpPut]
        [Route("ActualizarGrupo/")]
        public ActionResult<GrupoDto_Update> ActualizarDepartamento([FromBody] GrupoDto_Update grupo)
        {
            try
            {
                return _grupoDAO.ModificarGrupoDao(GrupoMapper.MapperDTOToEntityModificar(grupo));
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