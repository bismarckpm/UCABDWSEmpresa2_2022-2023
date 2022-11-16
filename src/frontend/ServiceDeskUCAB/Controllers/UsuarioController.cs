using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using ServiceDeskUCAB.Servicios;
using ServiceDeskUCAB.Models;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCAB.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IServicioUsuario_API _servicioApiUsuarios;

        public UsuarioController(ILogger<UsuarioController> logger, IServicioUsuario_API servicioApiUsuarios)
        {
            _logger = logger;
            _servicioApiUsuarios = servicioApiUsuarios;
        }

        public async Task<IActionResult> Usuarios()
        {
            List<Usuarios> ListaPlantillas = await _servicioApiUsuarios.Lista();
            return View(ListaPlantillas);
        }

        public IActionResult GuardarUsuarioView()
        {
            return View("GuardarUsuario");
        }

        public IActionResult RegistrarUsuario()
        {
            return View("~/Views/Login/SingUp");
        }

        [HttpPost]
        public async Task<IActionResult> GuardarUsuario(Usuarios plantilla)
        {

            JObject respuesta;

            try
            {
                respuesta = await _servicioApiUsuarios.Guardar(plantilla);

                if ((bool)respuesta["success"])
                {
                    return RedirectToAction("Usuarios");
                }
                else
                {
                    return RedirectToAction("Usuarios", new { message = (string)respuesta["message"] });
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
