using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using ServiceDeskUCAB.Models.PlantillaNotificaciones;
using ServiceDeskUCAB.ViewModel.PlantillaNotificaciones;
using ServiceDeskUCAB.Models.EstadoTicket;
using Microsoft.AspNetCore.Authorization;
using ServiceDeskUCAB.Servicios.ModuloPlantillaNotificacion;
using ServiceDeskUCAB.Servicios.ModuloTipoEstado;

namespace ServiceDeskUCAB.Controllers
{
    [Authorize(Policy = "AdminAccess")]
    public class PlantillaNotificacionController : Controller
    {
        private readonly ILogger<PlantillaNotificacionController> _logger;
        private readonly IServicioPlantillaNotificacion_API _servicioApiPlantillaNotificacion;
        private readonly IServicioTipoEstado_API _servicioApiTipoEstado;

        public PlantillaNotificacionController(ILogger<PlantillaNotificacionController> logger, IServicioPlantillaNotificacion_API servicioApiPlantillaNotificacion, IServicioTipoEstado_API servicioApiTipoEstado)
        {
            _logger = logger;
            _servicioApiPlantillaNotificacion = servicioApiPlantillaNotificacion;
            _servicioApiTipoEstado = servicioApiTipoEstado;
        }

        //Inicia la petición HTTP a la API para Obtener todas las plantillas de notificación a traves del servicio _servicioApiPlantillaNotificacion
        public async Task<IActionResult> PlantillasNotificacion()
        {
            List<PlantillaNotificacion> ListaPlantillas = await _servicioApiPlantillaNotificacion.Lista();
            return View(ListaPlantillas);
        }

        //Editar plantilla de notificación (Retorna la vista de Editar plantilla)
        public async Task<IActionResult> PlantillaEditar(Guid id)
        {
            PlantillaEditarViewModel plantillaEditarViewModel = new();

            PlantillaNotificacion plantillaNotificacion = await _servicioApiPlantillaNotificacion.Obtener(id);
            List<TipoEstado> ListaEstados = await _servicioApiTipoEstado.ListaHabilitados();

            plantillaEditarViewModel.TipoEstados = ListaEstados;
            plantillaEditarViewModel.Plantilla = plantillaNotificacion;

            return View(plantillaEditarViewModel);
        }

        //Crear una nueva plantilla de notificación (Retorna la vista de Nueva plantilla)
        public async Task<IActionResult> PlantillaNueva()
        {
            PlantillaNuevaViewModel plantillaNuevaViewModel = new();

            List<TipoEstado> ListaEstados = await _servicioApiTipoEstado.ListaHabilitados();

            plantillaNuevaViewModel.TipoEstados = ListaEstados;
            plantillaNuevaViewModel.Plantilla = new();

            return View(plantillaNuevaViewModel);
        }

        //Inicia la petición HTTP a la API para CREAR una nueva plantilla de notificación a traves del servicio _servicioApiPlantillaNotificacion
        [HttpPost]
        public async Task<IActionResult> GuardarPlantilla(PlantillaNotificacionNueva plantilla)
        {

            JObject respuesta;

            try
            {
                respuesta = await _servicioApiPlantillaNotificacion.Guardar(plantilla);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("PlantillasNotificacion");
                }
                else
                {
                    return RedirectToAction("PlantillaNueva", new { message = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        //Inicia la petición HTTP a la API para EDITAR una nueva plantilla de notificación a traves del servicio _servicioApiPlantillaNotificacion
        [HttpPost]
        public async Task<IActionResult> EditarPlantilla(PlantillaNotificacionNueva plantilla, string id)
        {
            JObject respuesta;

            try
            {
                respuesta = await _servicioApiPlantillaNotificacion.Editar(plantilla, id);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("PlantillasNotificacion");
                }
                else
                {
                    return RedirectToAction($"PlantillasNotificacion", new { message = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        //Inicia la petición HTTP a la API para Eliminar una nueva plantilla de notificación a traves del servicio _servicioApiPlantillaNotificacion
        [HttpGet]
        public async Task<IActionResult> EliminarPlantilla(Guid id)
        {
            JObject respuesta;

            respuesta = await _servicioApiPlantillaNotificacion.Eliminar(id);

            if ((bool)respuesta["success"])
                return RedirectToAction("PlantillasNotificacion", new { message = "Se ha eliminado correctamente", success = "true" });
            //return RedirectToAction("PlantillasNotificacion", new { message = (string)respuesta["message"] });
            else
                return RedirectToAction("PlantillasNotificacion", new { message = (string)respuesta["message"] });
        }
    }
}