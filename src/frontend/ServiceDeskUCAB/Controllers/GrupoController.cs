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
		/// <summary>
		/// Declaración de variables.
		/// </summary>
		
		private readonly ILogger<GrupoController> _logger;
		private readonly IServicioGrupo_API _servicioApiGrupo;
		private readonly IServicioDepartamento_API _servicioApiDepartamento;

        /// <summary>
        /// Constructor. 
        /// Inicialización de variables.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="servicioApiGrupo">Objeto de la interfaz que contiene los servicios de Grupo.</param>
        /// <param name="servicioApiDepartamento">Objeto de la interfaz que contiene los servicios de Departamento.</param>

        public GrupoController(ILogger<GrupoController> logger, IServicioGrupo_API servicioApiGrupo, IServicioDepartamento_API servicioApiDepartamento)
		{
			_logger = logger;
			_servicioApiGrupo = servicioApiGrupo;
			_servicioApiDepartamento = servicioApiDepartamento;
		}

        /// <summary>
        /// Inicia la petición HTTP a la API para obtener todas los grupos a traves del servicio ServicioGrupo_API.
        /// </summary>
        /// <returns>Devuelve una vista con una lista de grupos activos.</returns>

        public async Task<IActionResult> Index()
		{

			return View(await _servicioApiGrupo.ListaGrupo());
		}

		/// <summary>
		/// Método que incluye lista de departamentos y datos de un grupo seleccionado en un modal.
		/// </summary>
		/// <param name="id">Identificador de un grupo.</param>
		/// <returns>Devuelve un modal con los datos de un grupo y los departamentos que están asociados a este o no.</returns>
		
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

        /// <summary>
        /// Método que inicia la petición HTTP a la API para modificar los datos de un grupo y sus relaciones a traves del servicio ServicioGrupo_API.
        /// </summary>
        /// <param name="grupo">Objeto del tipo GrupoModel.
        /// Contiene la información suministrada en la View.</param>
        /// <param name="idDepartamentos">Lista de identificadores de departamentos.</param>
        /// <returns>Redirecciona a la view principal con una notificación.</returns>

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

        /// <summary>
        /// Inicia la petición HTTP a la API para obtener todas los departamentos asociados a un grupo.
		/// Se hace la petición a través del servicio ServicioGrupo_API.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <returns>Devuelve un modal con los departamentos asociados a un grupo.</returns>

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

        /// <summary>
        /// Método que invoca una view para eliminar un grupo seleccionado.
        /// </summary>
        /// <param name="id">Identificador del grupo.</param>
        /// <returns>Devuelve un modal con mensaje de confirmación.</returns>

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

        /// <summary>
        /// Método que inicia la petición HTTP a la API para eliminar un grupo a traves del servicio ServicioGrupo_API.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <returns>Devuelve la view principal con una notificación.</returns>

        [HttpGet]
		public async Task<IActionResult> EliminarGrupo(Guid id)
		{
			JObject respuesta;
			respuesta = await _servicioApiGrupo.EliminarGrupo(id);
			if ((bool)respuesta["success"])
				return RedirectToAction("Index", new { message = "Se ha eliminado correctamente" });
			else
				return RedirectToAction("Index", new { message2 = "Hubo un error en la operación" });
		}

        //Retorna el modal para registrar un grupo nuevo

        /// <summary>
        /// Método que inicia la petición HTTP a la API para obtener los departamentos no asociados.
		/// Se hace la petición a través del servicio ServicioGrupo_API.
        /// </summary>
        /// <returns>Devuelve un modal para agregar un departamento contiene Checkbox e InputText.</returns>

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

        /// <summary>
        /// Método que inicia la petición HTTP a la API para almacenar un grupo y sus relaciones.
		/// Se hace a través del servicio ServicioGrupo_API.
        /// </summary>
        /// <param name="grupo">Objeto de tipo GrupoModel</param>
        /// <param name="idDepartamentos">Lista de identificadores de departamentos.</param>
        /// <returns>Devuelve la view principal con una notificación.</returns>

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
