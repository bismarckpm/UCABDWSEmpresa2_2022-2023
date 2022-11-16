using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCAB.Dtos;
using ServicesDeskUCAB.Models;
using ServicesDeskUCAB.Servicios;
using ServicesDeskUCAB.Servicios.Prioridad;

namespace ServicesDeskUCAB.Controllers
{
    public class PrioridadController : Controller
    {
        private readonly IServicioAPI _servicioAPI;

        public PrioridadController(IServicioAPI servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public async Task<IActionResult> Index()
        {
            List<Prioridad> lista = await _servicioAPI.Lista();
            return View(lista);
        }

        public async Task<IActionResult> Prioridad(int prioridadID)
        {
            Prioridad prioridad = new Prioridad();
            ViewBag.Accion = "Nueva Prioridad";
            if (prioridadID != 0){
                prioridad = await _servicioAPI.Obtener(prioridadID);
                ViewBag.Accion = "Editar Prioridad";
            }
            return View(prioridad);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Prioridad prioridad){
            bool respuesta;
            if (prioridad.ID == 0)
            {
                respuesta = await _servicioAPI.Guardar(prioridad);
            }
            else
            {
                respuesta = await _servicioAPI.Editar(prioridad); 
            }
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
                return NoContent();
        }
    }
}

