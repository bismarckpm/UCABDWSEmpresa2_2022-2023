using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.OpenApi.Any;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios.ModuloDepartamento;
using ServiceDeskUCAB.Servicios.ModuloGrupo;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using System.Collections;

namespace ServiceDeskUCAB.Controllers
{
	public class DepartamentoYGrupoController : Controller
    {
		//Declaración de variables
		private readonly ILogger<DepartamentoYGrupoController> _logger;
		private readonly IServicioGrupo_API _servicioApiGrupo;
		private readonly IServicioDepartamento_API _servicioApiDepartamento;

		//Constructor
		public DepartamentoYGrupoController(ILogger<DepartamentoYGrupoController> logger, IServicioGrupo_API servicioApiGrupo, IServicioDepartamento_API servicioApiDepartamento)
		{
			_logger = logger;
			_servicioApiGrupo = servicioApiGrupo;
			_servicioApiDepartamento = servicioApiDepartamento;
		}

		//Inicia la petición HTTP a la API para Obtener todas los departamentos a traves del servicio ServicioDepartamento_API
		public async Task<IActionResult> DepartamentoGrupo()
		{
			var tupla = new Tuple<List<DepartamentoDto>, List<GrupoDto>>(null,null);
			tupla = await _servicioApiDepartamento.ListaDepartamentoGrupo();
			return View(tupla);
		}

		//Retorna el modal para registrar un departamento nuevo
		public IActionResult AgregarDepartamento()
		{
			try
			{
				return PartialView();
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}

		//Almacena la información referente a un nuevo departamento
		[HttpPost]
		public async Task<IActionResult> GuardarDepartamento(DepartamentoDto departamento)
		{

			JObject respuesta;

			try
			{
				respuesta = await _servicioApiDepartamento.RegistrarDepartamento(departamento);

				if ((bool)respuesta["success"])
				{
					return RedirectToAction("DepartamentoGrupo");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return NoContent();
		}

		//Retorna el modal para eliminar un departamento
		public IActionResult VentanaEliminarDepartamento(Guid id)
		{
			try
			{
				return PartialView(id);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}

		//Elimina a un departamento que ha sido seleccionado previamente
		[HttpGet]
		public async Task<IActionResult> EliminarDepartamento(Guid id)
		{
			JObject respuesta;
			respuesta = await _servicioApiDepartamento.EliminarDepartamento(id);
			if ((bool)respuesta["success"])
				return RedirectToAction("DepartamentoGrupo", new { message = "Se ha eliminado correctamente" });
			else
				return NoContent();
		}

		public async Task<IActionResult> VentanaEditarDepartamento(Guid id) {
			try
			{
				DepartamentoModel departamento = new DepartamentoModel();
				departamento = await _servicioApiDepartamento.MostrarInfoDepartamento(id);
				return PartialView(departamento);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}

		public async Task<IActionResult> ModificarDepartamento(DepartamentoDto_Update dept) {
			try
			{
				JObject respuesta;
				respuesta = await _servicioApiDepartamento.EditarDepartamento(dept);
				if ((bool)respuesta["success"])
					return RedirectToAction("DepartamentoGrupo", new { message = "Se ha modificado correctamente" });
			}
			catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
			return NoContent();
		}

		/////////////
		///Operaciones de grupo
		////////////

		//Retorna el modal con los departamentos que estan asociados a un grupo
		public async Task<IActionResult> VentanaVisualizarDepartamento(Guid id)
		{
			List<DepartamentoModel> departamento = new List<DepartamentoModel>();
			GrupoModel model = new GrupoModel();

			try
			{
				model = await _servicioApiGrupo.BuscarGrupo(id);
				ViewData["nombre"] = model.nombre;
				departamento = await _servicioApiDepartamento.DepartamentoAsociadoGrupo(id);
				return PartialView(departamento);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}
		//Retorna el modal de confirmación para eliminar un grupo
		public async Task<IActionResult> VentanaEliminarGrupo(Guid id)
		{
			try
			{
				return PartialView(id);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}
		//
		[HttpGet]
		public async Task<IActionResult> EliminarGrupo(Guid id)
		{
			JObject respuesta;
			respuesta = await _servicioApiGrupo.EliminarGrupo(id);
			if ((bool)respuesta["success"])
				return RedirectToAction("DepartamentoGrupo", new { message = "Se ha eliminado correctamente" });
			else
				return NoContent();
		}

		//Retorna el modal para registrar un grupo nuevo
		public async Task<IActionResult> AgregarGrupo()
		{
			GrupoModel grupo = new GrupoModel();
			var tupla = new Tuple<List<DepartamentoModel>,DepartamentoModel,GrupoModel> (null,null,null);

			try
			{
				tupla = await _servicioApiGrupo.tuplaModelDepartamento();
				return PartialView(tupla);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
			return NoContent();
		}

		
		public async Task<IActionResult> RegistrarGrupo( List<string> idDepartamentos) {

			Console.WriteLine(idDepartamentos.Count());
            return RedirectToAction("DepartamentoGrupo");	
			
		}
	}
}
