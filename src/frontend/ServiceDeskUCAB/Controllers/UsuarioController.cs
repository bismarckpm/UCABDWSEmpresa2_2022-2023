using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using ServiceDeskUCAB.Servicios;
using ServiceDeskUCAB.Models;

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


    }
}
