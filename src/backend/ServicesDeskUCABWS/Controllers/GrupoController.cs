using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.DTO;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Persistence.DAO.Interface;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
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








		//private readonly GrupoServices _services;
		//private readonly DataContext _dataContext;

		//public GrupoController(GrupoServices services, DataContext data)
		//{
		//	_services = services;
		//	_dataContext = data;
		//}

		//[HttpPost]
		//public async Task<IActionResult> RegistrarGrupo(GrupoDto grupoDto)
		//{

		//	var otraVar = await _services.Create(grupoDto);
		//	return CreatedAtAction(null, new { otraVar.Id }, otraVar);
		//}

		//[HttpGet]
		//public async Task<IEnumerable<Grupo>> ListarGrupo()
		//{
		//	return await _services.GetAll();
		//}

		//[HttpDelete("{Guid}")]
		//public async Task<IActionResult> EliminarDepartamento(GrupoDto grupoDto)
		//{

		//	var existeDep = await _services.GetById(grupoDto.Id);

		//	if (existeDep is not null)
		//	{

		//		await _services.Delete(grupoDto.Id);
		//		return Ok();
		//	}
		//	else
		//	{
		//		return NotFound();
		//	}
		//}

		//[HttpPut("{Guid}")]
		//public async Task<IActionResult> ModificarGrupo(GrupoDto grupoDto)
		//{

		//	var existeDep = await _services.GetById(grupoDto.Id);

		//	if (existeDep is not null)
		//	{
		//		await _services.Update(grupoDto);

		//		return NoContent();
		//	}
		//	else
		//	{
		//		return NotFound(grupoDto);
		//	}
		//}
	}
}
