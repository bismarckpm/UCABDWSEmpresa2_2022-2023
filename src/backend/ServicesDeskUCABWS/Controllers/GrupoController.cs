using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
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
