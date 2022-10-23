using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Database;
using ServicesDeskUCABWS.Services;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicesDeskUCABWS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartamentoController : ControllerBase
	{

		private readonly DataContext _dataContext;
		private readonly IMapper _mapeador;
		private readonly DepartamentoServices _departamento;

		public DepartamentoController(DataContext dataContext, IMapper mapeador, DepartamentoServices departamento)
		{
			_dataContext = dataContext;
			_mapeador = mapeador;
			_departamento = departamento;
		}

		// POST api/<DepartamentoController>
		[HttpPost]
		public async Task<IActionResult> CreateDepartamento(DepartamentoDto depaDto)
		{
			var otraVar = await _departamento.Create(depaDto);
			return CreatedAtAction(null, new { otraVar.Id }, otraVar);
		}
	}
}
