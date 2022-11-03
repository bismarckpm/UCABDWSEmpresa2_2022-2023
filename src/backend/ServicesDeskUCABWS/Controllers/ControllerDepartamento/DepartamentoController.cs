using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperDepartamento;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicesDeskUCABWS.Controllers.ControllerDepartamento
{
    [Route("Departamento")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoDAO _departamentoDAO;
        private readonly ILogger<DepartamentoController> _log;

        //Constructor
        public DepartamentoController(IDepartamentoDAO departamentoDAO, ILogger<DepartamentoController> log)
        {
            _departamentoDAO = departamentoDAO;
            _log = log;
        }


        //Crear Departamento
        [HttpPost]
        [Route("CrearDepartamento/")]
        public ActionResult<DepartamentoDto> CrearDepartamento([FromBody] DepartamentoDto dto1)
        {
            try
            {
                var dao = _departamentoDAO.AgregarDepartamentoDAO(DepartamentoMapper.MapperDTOToEntity(dto1));
                return dao;

            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpGet]
        [Route("ConsultarDepartamento/")]
        public ActionResult<List<DepartamentoDto>> ConsultarDepartamentos()
        {
            try
            {
                return _departamentoDAO.ConsultarDepartamentos();
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpGet]
        [Route("ConsultarDepartamentoPorID/{id}")]
        public ActionResult<DepartamentoDto> ConsultarPorID([FromRoute] Guid id)
        {
            try
            {
                return _departamentoDAO.ConsultarPorID(id);
            }
            catch (Exception ex)
            {

                throw ex.InnerException!;
            }
        }

        [HttpDelete]
        [Route("EliminarDepartamento/{id}")]
        public ActionResult<DepartamentoDto> EliminarDepartamento([FromRoute] Guid id)
        {
            try
            {
                return _departamentoDAO.eliminarDepartamento(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpPut]
        [Route("ActualizarDepartamento/")]
        public ActionResult<DepartamentoDto_Update> ActualizarDepartamento([FromBody] DepartamentoDto_Update departamento)
        {
            try
            {
                return _departamentoDAO.ActualizarDepartamento(DepartamentoMapper.MapperDTOToEntityModificar(departamento));
                //Cambiar parametros cuando realicemos frontend

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        [HttpGet("AsignarGrupoToDepartamento/{idGrupo}")]
        public ActionResult<List<DepartamentoDto>> ListaDepartamentosGrupo(Guid idGrupo)
        {
            try
            {
                return _departamentoDAO.GetByIdDepartamento(idGrupo);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

        [HttpPost("ConsultarDepartamentosPorIdGrupo/{idGrupo}/{idDept}")]
        public ActionResult<Departamento> AsignarGrupoToDepartamento(Guid idGrupo, Guid idDept)
        {
            try
            {
                return _departamentoDAO.AsignarGrupoToDepartamento(idGrupo, idDept);
            }
            catch (Exception ex)
            {
                throw ex.InnerException!;
            }
        }

    }
}
