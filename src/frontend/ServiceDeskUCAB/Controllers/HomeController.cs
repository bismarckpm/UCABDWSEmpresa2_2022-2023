using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ViewModel;
using ServiceDeskUCAB.Servicios;
using System.Diagnostics;
using System.Dynamic;

namespace ServiceDeskUCAB.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}