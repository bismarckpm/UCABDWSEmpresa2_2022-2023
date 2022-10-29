using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Database;
using ServicesDeskUCABWS.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicesDeskUCABWS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartamentoController : ControllerBase
	{
		private readonly DepartamentoServices _services;

		//Constructor
		public DepartamentoController(DepartamentoServices services)
		{
			_services = services;
		}

		// POST api/<DepartamentoController>
		[HttpPost]
		public async Task<IActionResult>RegistrarDepartamento(DepartamentoDto depDto) {

			var otraVar = await _services.Create(depDto);
			return CreatedAtAction(null, new { otraVar.Id }, otraVar);
		}

		[HttpGet]
		public async Task<IEnumerable<Departamento>> ListarDepartamento()
		{
			return await _services.GetAll();
		}

		[HttpDelete("{Guid}")]
		public async Task<IActionResult> EliminarDepartamento(DepartamentoDto depDto)
		{

			var existeDep = await _services.GetById(depDto.Id);

			if (existeDep is not null)
			{

				await _services.Delete(depDto.Id);
				return Ok();
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPut("{Guid}")]
		public async Task<IActionResult> ModificarDepartamento(DepartamentoDto depDto)
		{

			var existeDep = await _services.GetById(depDto.Id);

			if (existeDep is not null)
			{
				await _services.Update(depDto);
				
				return NoContent();
			}
			else
			{
				return NotFound(depDto);
			}
		}

		[HttpGet("{idGrupo}")]
		public async Task<ActionResult<IEnumerable<Departamento>>> ListaDepartamento(Guid idGrupo)
		{

			/*var listaDepartamentos = _dataContext.Grupos
			   .Include(grup => grup.Departamento)
			   .FirstOrDefault(dept => dept.Id == idGrupo);

			if (listaDepartamentos is null)
				return NotFound(idGrupo);*/



			return await _services.GetByIdDepartamento(idGrupo);
		}

	}
}
