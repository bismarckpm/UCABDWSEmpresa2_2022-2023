using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios.ModuloDepartamento;
using ServiceDeskUCAB.Servicios.ModuloGrupo;
using ServiceDeskUCAB.ViewModel.DepartamentoGrupo;
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
			var tupla = new Tuple<List<DepartamentoModel>, List<GrupoModel>>(null,null);
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
		public async Task<IActionResult> GuardarDepartamento(DepartamentoModel departamento)
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

		public async Task<IActionResult> ModificarDepartamento(DepartamentoModel dept) {
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

		//Retorna el modal con los departamentos que se desea asociar
		public async Task<IActionResult> AsociarGrupo(GrupoModel grupo, List<string> idDepartamentos)
		{
			JObject respuesta;

			try
			{
				
				respuesta = await _servicioApiDepartamento.AsociarDepartamento(grupo.id, idDepartamentos);
				if ((bool)respuesta["success"])
					return RedirectToAction("DepartamentoGrupo", new { message = "Se ha asociado correctamente" });
				else
					return NoContent();
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}

		//Retorna el modal con los departamentos que se desea asociar
		public async Task<IActionResult> VentanaAsociarDepartamento(Guid id)
		{
			DepartamentoAsociarViewModel departamento = new DepartamentoAsociarViewModel();


			try
			{
				departamento.grupo = await _servicioApiGrupo.BuscarGrupo(id);
				ViewData["nombre"] = departamento.grupo.nombre;
				departamento.departamentoNoAsoc = await _servicioApiDepartamento.ListaDepartamentoNoAsociado();

				return PartialView(departamento);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}

		//Retorna el modal con la lista de departamentos y los datos del grupo seleccionado
		public async Task<IActionResult> VentanaEditarGrupo(Guid id)
		{
			GrupoEditarViewModel viewModel = new GrupoEditarViewModel();

			try
			{
				viewModel.deptAsociado = await _servicioApiDepartamento.DepartamentoAsociadoGrupo(id);
				viewModel.departamento = await _servicioApiDepartamento.ListaDepartamento();
				viewModel.grupo = await _servicioApiGrupo.BuscarGrupo(id);
				return PartialView(viewModel);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}

		//Retorna el modal con los departamentos que serán asociados a un grupo
		public async Task<IActionResult> VentanaVisualizarDepartamento(Guid id)
		{
			DepartamentoModel departamento = new DepartamentoModel();
			GrupoModel model = new GrupoModel ();

			try
			{
				model  = await _servicioApiGrupo.BuscarGrupo(id);
				ViewData["nombre"] = model.nombre;
				departamento.departamentos = await _servicioApiDepartamento.DepartamentoAsociadoGrupo(id);
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

			try
			{
				return PartialView(grupo);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
			return NoContent();
		}

		
		public async Task<IActionResult> GuardarGrupo(GrupoModel grupo) {

			JObject respuestaGrupo;

			try
			{
				respuestaGrupo = await _servicioApiGrupo.RegistrarGrupo(grupo);
				return RedirectToAction("DepartamentoGrupo");
					
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return NoContent();

		}
	}
}
