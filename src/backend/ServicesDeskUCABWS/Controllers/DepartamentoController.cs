using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.DTO;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Persistence.DAO.Interface;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
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
        public ActionResult<DepartamentoDto_Update> ActualizarDireccion([FromBody] DepartamentoDto_Update departamento)
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

        //[HttpGet("{idGrupo}")]
        //public async Task<ActionResult<IEnumerable<Departamento>>> ListaDepartamento(Guid idGrupo)
        //{

        //	/*var listaDepartamentos = _dataContext.Grupos
        //	   .Include(grup => grup.Departamento)
        //	   .FirstOrDefault(dept => dept.Id == idGrupo);

        //	if (listaDepartamentos is null)
        //		return NotFound(idGrupo);*/



        //	return await _services.GetByIdDepartamento(idGrupo);
        //}

    }
}
