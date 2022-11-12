using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServicesDeskUCAB.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CrearTicket()
        {
            return View();
        }
        public IActionResult Merge()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}

