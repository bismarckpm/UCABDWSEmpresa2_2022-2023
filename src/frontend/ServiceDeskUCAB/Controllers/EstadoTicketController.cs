using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.EstadoTicket;
using ServiceDeskUCAB.Servicios;
using ServiceDeskUCAB.ViewModel.EstadoTicket;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ServiceDeskUCAB.Controllers
{
    public class EstadoTicketController : Controller
    {
        private readonly ILogger<EstadoTicketController> _logger;
        private readonly IServicioPlantillaNotificacion_API _servicioApiPlantillaNotificacion;
        private readonly IServicioTipoEstado_API _servicioApiTipoEstado;

        public EstadoTicketController(ILogger<EstadoTicketController> logger, IServicioTipoEstado_API servicioApiTipoEstado)
        {
            _logger = logger;
            _servicioApiTipoEstado = servicioApiTipoEstado;
        }

        public async Task<IActionResult> EstadosTicket()
        {
            List<TipoEstado> ListaPlantillas = await _servicioApiTipoEstado.Lista();
            return View(ListaPlantillas);
        }

        public async Task<IActionResult> EstadoNuevo()
        {
            EstadoNuevoViewModel estadoNuevoViewModel = new();

            List<Etiqueta> ListaEtiquetas = await _servicioApiTipoEstado.ListaEtiqueta();

            estadoNuevoViewModel.Etiquetas = ListaEtiquetas;
            estadoNuevoViewModel.Estado = new();

            return View(estadoNuevoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarEstado(TipoEstadoNuevo tipoEstadoNuevo)
        {

            JObject respuesta;

            try
            {
                respuesta = await _servicioApiTipoEstado.Guardar(tipoEstadoNuevo);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("EstadosTicket");
                }
                else
                {
                    return RedirectToAction("EstadoNuevo", new { message = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> EliminarEstado(Guid id)
        {
            JObject respuesta;
            respuesta = await _servicioApiTipoEstado.Eliminar(id);
            if ((bool)respuesta["success"])
                return RedirectToAction("EstadosTicket", new { message = "Se ha eliminado correctamente" });
            //return RedirectToAction("PlantillasNotificacion", new { message = (string)respuesta["message"] });
            else
                return RedirectToAction("EstadosTicket", new { message = (string)respuesta["message"] });
        }

        public async Task<IActionResult> EstadoEditar(Guid id)
        {
            EstadoEditarViewModel estadoEditarViewModel = new();

            TipoEstado tipoEstado = await _servicioApiTipoEstado.Obtener(id);
            List<Etiqueta> etiquetas = await _servicioApiTipoEstado.ListaEtiqueta();

            estadoEditarViewModel.Etiquetas = etiquetas;
            estadoEditarViewModel.Estado = tipoEstado;

            return View(estadoEditarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstado(TipoEstadoNuevo estado, string id)
        {

            if (estado.Etiqueta == null)
            {
                estado.Etiqueta = new();
            }

            JObject respuesta;

            try
            {
                respuesta = await _servicioApiTipoEstado.Editar(estado, id);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("EstadosTicket");
                }
                else
                {
                    return RedirectToAction("EstadoEditar", new { message = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }
    }
}