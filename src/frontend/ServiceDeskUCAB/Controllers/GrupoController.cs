using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios.ModuloDepartamento;
using ServiceDeskUCAB.Servicios.ModuloGrupo;
using ServiceDeskUCAB.ViewModel.Grupo;

namespace ServiceDeskUCAB.Controllers
{
    [Authorize(Policy = "AdminAccess")]
	public class GrupoController : Controller
    {
		//Declaración de variables
		private readonly ILogger<GrupoController> _logger;
		private readonly IServicioGrupo_API _servicioApiGrupo;
		private readonly IServicioDepartamento_API _servicioApiDepartamento;

		//Constructor
		public GrupoController(ILogger<GrupoController> logger, IServicioGrupo_API servicioApiGrupo, IServicioDepartamento_API servicioApiDepartamento)
		{
			_logger = logger;
			_servicioApiGrupo = servicioApiGrupo;
			_servicioApiDepartamento = servicioApiDepartamento;
		}

		//Inicia la petición HTTP a la API para Obtener todas los grupos a traves del servicio ServicioGrupo_API
		public async Task<IActionResult> Index()
		{

			return View(await _servicioApiGrupo.ListaGrupo());
		}

		//Retorna el modal con la lista de departamentos y los datos del grupo seleccionado
		public async Task<IActionResult> VentanaEditarGrupo(Guid id)
		{
			GrupoEditarViewModel viewModel = new GrupoEditarViewModel();

			try
			{
				viewModel.deptAsociado = await _servicioApiGrupo.DepartamentoAsociadoGrupo(id);
				viewModel.departamento = await _servicioApiDepartamento.ListaDepartamento();
				viewModel.grupo = await _servicioApiGrupo.BuscarGrupo(id);
				return PartialView(viewModel);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
		}

		public async Task<IActionResult> ModificarGrupo(GrupoModel grupo, List<string> idDepartamentos)
		{
			JObject respuesta;
			JObject respuestaDept;
			respuesta = await _servicioApiGrupo.EditarGrupo(grupo);
			if ((bool)respuesta["success"]) {
                respuestaDept = await _servicioApiGrupo.EditarRelacion(grupo.id, idDepartamentos);
                return RedirectToAction("Index", new { message = "Se ha modificado correctamente" });
            }else return RedirectToAction("Index", new { message2 = "El nombre del grupo ingresado ya existe" });
            
        }

		//Retorna el modal con los departamentos que serán asociados a un grupo
		public async Task<IActionResult> VentanaVisualizarDepartamento(Guid id)
		{
			DepartamentoModel departamento = new DepartamentoModel();
			GrupoModel model = new GrupoModel();

			try
			{
				model = await _servicioApiGrupo.BuscarGrupo(id);
				ViewData["nombre"] = model.nombre;
				departamento.departamentos = await _servicioApiGrupo.DepartamentoAsociadoGrupo(id);
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

		[HttpGet]
		public async Task<IActionResult> EliminarGrupo(Guid id)
		{
			JObject respuesta;
			respuesta = await _servicioApiGrupo.EliminarGrupo(id);
			if ((bool)respuesta["success"])
				return RedirectToAction("Index", new { message = "Se ha eliminado correctamente" });
			else
				return NoContent();
		}

		//Retorna el modal para registrar un grupo nuevo
		public async Task<IActionResult> VentanaAgregarGrupo()
		{
			GrupoRegistrarViewModel viewModel = new GrupoRegistrarViewModel();
            viewModel.deptNoAsociado = await _servicioApiDepartamento.ListaDepartamentoNoAsociado();

            try
			{
				return PartialView(viewModel);
			}
			catch (Exception ex)
			{
				throw ex.InnerException!;
			}
			return NoContent();
		}


		public async Task<IActionResult> GuardarGrupo(GrupoModel grupo, List<string> idDepartamentos)
		{

			JObject respuestaGrupo;
			JObject respuestaRelacion;

			try
			{
				respuestaGrupo = await _servicioApiGrupo.RegistrarGrupo(grupo, idDepartamentos);
				if ((bool)respuestaGrupo["success"]) {
					if (idDepartamentos.Count() > 0)
					{
						var respuestaConsulta = await _servicioApiGrupo.BuscarNombreGrupo(grupo.nombre);
						respuestaRelacion = await _servicioApiGrupo.AsociarDepartamento(respuestaConsulta.id, idDepartamentos);
						return RedirectToAction("Index", new { message = "Se ha registrado correctamente" });
					}
					
                    return RedirectToAction("Index", new { message = "Se ha registrado corréctamente, sin departamentos asociados" }); 
				}
				else return RedirectToAction("Index", new { message2 = "El nombre del grupo ingresado ya existe" });
                    
                
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return NoContent();
		}
	}
}
