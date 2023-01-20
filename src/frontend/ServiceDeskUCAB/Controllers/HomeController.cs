using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ViewModel;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Dynamic;
using ServiceDeskUCAB.Servicios.ModuloPlantillaNotificacion;
using ServiceDeskUCAB.Models.Modelos_de_Usuario;
using ServiceDeskUCAB.Servicios;

namespace ServiceDeskUCAB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioPlantillaNotificacion_API _servicioApi;
        private readonly IServicioUsuario_API _servicioUsuarioApi;

        public HomeController(ILogger<HomeController> logger, IServicioPlantillaNotificacion_API servicioApi, IServicioUsuario_API servicioApiUsuarios)
        {
            _logger = logger;
            _servicioApi = servicioApi;
            _servicioUsuarioApi = servicioApiUsuarios;
        }
        
        public async Task<IActionResult> Index()
        {
            try
            {
                //var current = User.Identities.First().Claims.ToList()[2].Value;
                var current = User.Identities.First().Claims.ToList()[0].Value;
                UsuariosRol usuario = new UsuariosRol();

                usuario = await _servicioUsuarioApi.MostrarInfoUsuario(Guid.Parse(current));
                var boold = User.Identities.First().Claims.ToList()[2].Value == "Cliente";
                if (current == null)
                {
                    return View(usuario);
                }
                else
                {
                    return View(usuario);
                }
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel() { RequestId = ex.Message});
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

