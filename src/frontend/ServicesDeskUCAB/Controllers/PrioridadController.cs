using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCAB.Dtos;

namespace ServicesDeskUCAB.Controllers
{
    public class PrioridadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CrearPrioridad()
        {
            return View();
        }
    }
}

