using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ViewModel;
using ServiceDeskUCAB.Servicios;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Dynamic;

namespace ServiceDeskUCAB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioPlantillaNotificacion_API _servicioApi;

        public HomeController(ILogger<HomeController> logger, IServicioPlantillaNotificacion_API servicioApi)
        {
            _logger = logger;
            _servicioApi = servicioApi;
        }
        
        public async Task<IActionResult> Index()
        {
            //var current = User.Identities.First().Claims.ToList()[2].Value;
            var current = User.Identities.First().Claims;
            var boold = User.Identities.First().Claims.ToList()[2].Value == "Cliente";
            if (current == null)
            {
                Console.WriteLine("asdasdadas");
                return View();
            }
            else
            {
                return View();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

