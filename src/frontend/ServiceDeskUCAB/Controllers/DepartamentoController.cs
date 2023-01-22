using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios.ModuloDepartamento;
using ServiceDeskUCAB.Servicios.ModuloGrupo;

namespace ServiceDeskUCAB.Controllers
{
	[Authorize(Policy = "AdminAccess")]
	public class DepartamentoController : Controller
    {
        /// <summary>
        /// Declaración de variables.
        /// </summary>
		
        private readonly ILogger<DepartamentoController> _logger;
		private readonly IServicioDepartamento_API _servicioApiDepartamento;

        /// <summary>
        /// Constructor. 
        /// Inicialización de variables.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="servicioApiDepartamento">Objeto de la interfaz que contiene los servicios de Departamento.</param>
        public DepartamentoController(ILogger<DepartamentoController> logger, IServicioDepartamento_API servicioApiDepartamento)
		{
			_logger = logger;
			_servicioApiDepartamento = servicioApiDepartamento;
		}

        /// <summary>
        /// Inicia la petición HTTP a la API para obtener todas los departamentos a traves del servicio ServicioDepartamento_API.
        /// </summary>
        /// <returns>Devuelve una vista con una lista de departamentos activos.</returns>
        public async Task<IActionResult> Index()
		{

			return View(await _servicioApiDepartamento.ListaDepartamento());
		}

        /// <summary>
        /// Método que invoca una view para agregar un departamento.
        /// </summary>
        /// <returns>Devuelve un modal con los campos necesarios para registrar un departamento.</returns>
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

        /// <summary>
        /// Método que inicia la petición HTTP a la API para almacenar un departamento 
		/// Se hace a través del servicio ServicioDepartamento_API.
        /// </summary>
        /// <param name="departamento">Objeto de tipo DepartamentoModel</param>
        /// <returns>Devuelve la view principal con una notificación.</returns>
        [HttpPost]
		public async Task<IActionResult> GuardarDepartamento(DepartamentoModel departamento)
		{

			JObject respuesta;

			try
			{
				respuesta = await _servicioApiDepartamento.RegistrarDepartamento(departamento);

				if ((bool)respuesta["success"])
				{
					return RedirectToAction("Index", new { message = "Se ha agregado correctamente" });
				}
				else return RedirectToAction("Index", new { message2 = "El nombre del departamento ingresado ya existe" });
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return NoContent();
		}

        /// <summary>
        /// Método que invoca una view para eliminar un departamento seleccionado.
        /// </summary>
        /// <param name="id">Identificador del departamento.</param>
        /// <returns>Devuelve un modal con mensaje de confirmación.</returns>
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

        /// <summary>
        /// Método que inicia la petición HTTP a la API para eliminar un departamento a traves del servicio ServicioDepartamento_API.
        /// </summary>
        /// <param name="id">Identificador de un departamento.</param>
        /// <returns>Devuelve la view principal con una notificación.</returns>
        [HttpGet]
		public async Task<IActionResult> EliminarDepartamento(Guid id)
		{
			JObject respuesta;
			respuesta = await _servicioApiDepartamento.EliminarDepartamento(id);
			if ((bool)respuesta["success"])
				return RedirectToAction("Index", new { message = "Se ha eliminado correctamente" });
			else
				return NoContent();
		}

        /// <summary>
        /// Método que invoca una view para editar el departamento seleccionado.
        /// </summary>
        /// <returns>Devuelve un modal con los campos necesarios para editar un departamento.</returns>
        public async Task<IActionResult> VentanaEditarDepartamento(Guid id)
		{
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

        /// <summary>
        /// Método que inicia la petición HTTP a la API para modificar los datos de un departamento a traves del servicio ServicioDepartamento_API.
        /// </summary>
        /// <param name="dept">Objeto del tipo DepartamentoModel.
        /// Contiene la información suministrada en la View.</param>
        /// <returns>Redirecciona a la view principal de departamento con una notificación.</returns>
        public async Task<IActionResult> ModificarDepartamento(DepartamentoModel dept)
		{
			try
			{
				JObject respuesta;
				respuesta = await _servicioApiDepartamento.EditarDepartamento(dept);
				if ((bool)respuesta["success"])
					return RedirectToAction("Index", new { message = "Se ha modificado correctamente" });
                else return RedirectToAction("Index", new { message2 = "El nombre del departamento ingresado ya existe" });
            }	

            catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			return NoContent();
		}
	}
}
