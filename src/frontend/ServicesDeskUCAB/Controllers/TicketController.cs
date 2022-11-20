using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCAB.Models;
using ServicesDeskUCAB.Servicios.Ticket;
using ServicesDeskUCAB.ViewModel;

namespace ServicesDeskUCAB.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index(string opcion)
        {
            ViewBag.opcion = opcion;
            List<Ticket> lista = new List<Ticket>();
            return View(lista);
        }
        public IActionResult Ticket()
        {
            Ticket ticket = new Ticket();
            return View(ticket);
        }
        public IActionResult Merge()
        {
            TicketMergeViewModel ticketMergeViewModel = new TicketMergeViewModel()
            {

            };
            return View(ticketMergeViewModel);
        }

        public IActionResult Details()
        {
            TicketDetailsViewModel ticketDetailsViewModel = new TicketDetailsViewModel()
            {

            };
            return View(ticketDetailsViewModel);
        }

        public IActionResult Reenviar()
        {
            TicketReenviarViewModel ticketReenviarViewModel = new TicketReenviarViewModel()
            {

            };
            return View(ticketReenviarViewModel);
        }

        public IActionResult GuardarCambios()
        {
            return View();
        }
    }
}

