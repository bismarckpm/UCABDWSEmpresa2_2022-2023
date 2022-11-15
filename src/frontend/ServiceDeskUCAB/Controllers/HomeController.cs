﻿using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios;
using System.Diagnostics;
using System.Dynamic;

namespace ServiceDeskUCAB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicio_API _servicioApi;

        public HomeController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> VistaTipoTicket()
        {
            List<Tipo> lista = await _servicioApi.Lista();

            return View(lista);
        }

        public async Task<IActionResult> VistaTicket()
        {
            List<Ticket> lista = await _servicioApi.ListaTickets();

            return View(lista);
        }

        [HttpGet]
        public async Task<IActionResult> AgregarTicket()
        {

            var ticket = new Ticket() {Id = new Guid()};

            var departamentos = await _servicioApi.ObtenerDepartamentos();
            var prioridades = await _servicioApi.ObtenerPrioridades();
            var tipos = await _servicioApi.Lista();

            ViewData["Departamentos"] = departamentos;
            ViewData["Prioridades"] = prioridades;
            ViewData["Tipos"] = tipos;

            return View(ticket);
        }

        [HttpGet]
        public async Task<IActionResult> GuardarTicket(Ticket ticket, string Emisor)
        {
            ticket.Emisor = Emisor;
            var respuesta = await _servicioApi.AgregarTicket(ticket);

            if (respuesta)
                return RedirectToAction("VistaTicket");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> EliminarTipoTicket(int idTipo)
        {
            var respuesta = await _servicioApi.Eliminar(idTipo);

            if (respuesta)
                return RedirectToAction("VistaTipoTicket");
            else
                return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> ModificarTipoTicket(string id_tipo)
        {

            var tipo = await _servicioApi.ObtenerTipoTicket(id_tipo);

            return View(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarTipoTicket(Tipo tipo_ticket)
        {

            var respuesta = await _servicioApi.Modificar(tipo_ticket);

            if (respuesta)
                return RedirectToAction("VistaTipoTicket");
            else
                return NoContent();
        }

        // controladores para votar ticket, Get de vista y Post de Guardar

        [HttpGet]
        public IActionResult VistaVotarTicket(string idUsuario, string idTicket)
        {
            var voto = new VotarTicket() { IdTicket = idTicket, IdUsuario = idUsuario};

            return View(voto);
        }

        [HttpPost]
        public async Task<IActionResult> VotarTicket(VotarTicket voto_ticket)
        {

            var respuesta = await _servicioApi.VotarTicket(voto_ticket);

            if (respuesta)
                return RedirectToAction("VistaTicket");
            else
                return NoContent();
        }

        public async Task<IActionResult> Index()
        {
   
            return View();
        }
    }
}