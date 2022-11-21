using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using ServicesDeskUCAB.Servicios;

namespace ServicesDeskUCAB.Controllers
{
    public class PrioridadController : Controller
    {
        private readonly IServicioPrioridadAPI _servicioAPI;

        public PrioridadController(IServicioPrioridadAPI servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public async Task<IActionResult> Index(string mensaje = "")
        {
            ViewBag.Mensaje = mensaje;
            List<Prioridad> lista = await _servicioAPI.Lista();
            return View(lista);
        }

        public async Task<IActionResult> Prioridad(Guid prioridadID)
        {
            Prioridad prioridad = new Prioridad();
            ViewBag.Accion = "Nueva Prioridad";
            Console.WriteLine("Esta es la guid ",prioridadID);
            if (prioridadID != Guid.Empty){
                prioridad = await _servicioAPI.Obtener(prioridadID);
                ViewBag.Accion = "Editar Prioridad";
                Console.WriteLine(await _servicioAPI.Obtener(prioridadID));
            }
            return View(prioridad);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Prioridad prioridad){
            JObject respuesta;
            try
            {
                if (prioridad.Id == Guid.Empty)
                {
                    prioridad.Id = Guid.NewGuid();
                    respuesta = await _servicioAPI.Guardar(prioridad);
                    Console.WriteLine(respuesta);
                    if ((bool) respuesta["success"])
                    {
                        Console.WriteLine("La respuesta fue verdadera");
                        return RedirectToAction("Index", new { message = (string)respuesta["message"] });

                    }
                    else
                    {
                        Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                        return RedirectToAction("Prioridad", new { message = (string)respuesta["message"] });
                    }
                }
                else
                {
                    respuesta = await _servicioAPI.Editar(prioridad);
                    if ((bool)respuesta["success"])
                    {
                        return RedirectToAction("Index", new { message = (string)respuesta["message"] });
                    }
                    else
                    {
                        return RedirectToAction("Prioridad", new { message = (string)respuesta["message"] });
                    }
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