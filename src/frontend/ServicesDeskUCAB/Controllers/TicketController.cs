using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using ServicesDeskUCAB.Servicios;
using ServicesDeskUCAB.ViewModel;

namespace ServicesDeskUCAB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServicioTicketAPI _servicioTicketAPI;
        private readonly IServicioPrioridadAPI _servicioPrioridadAPI;
        //private readonly IServicioTipoTicketAPI _servicioTipoTicketAPI;
        //private readonly IServicioDepartamento _servicioDepartamentoAPI;

        public TicketController(IServicioPrioridadAPI servicioPrioridadAPI,IServicioTicketAPI servicioTicketAPI/*, IServicioTipoTicketAPI servicioTipoTicketAPI, IServicioDepartamento servicioDepartamento*/)
        {
            _servicioTicketAPI = servicioTicketAPI;
            //_servicioTipoTicketAPI = servicioTipoTicketAPI;
            //_servicioDepartamentoAPI = servicioDepartamentoAPI:
            _servicioPrioridadAPI = servicioPrioridadAPI;
        }

        public async Task<IActionResult> Index(string departamentoId,string opcion)
        {
            ViewBag.opcion = opcion;
            ViewBag.departamentoId = departamentoId;
            List<Ticket> lista = await _servicioTicketAPI.Lista(departamentoId,opcion);
            return View(lista);
        }

        public async Task<IActionResult> Ticket(string ticketPadreId = "")
        {
            TicketNuevoViewModel ticketNuevoViewModel = new TicketNuevoViewModel
            {
                ticket = new Ticket(),
                prioridades = await _servicioPrioridadAPI.Lista(),
                departamentos = new List<Departamento>(), // await _servicioDepartamentoAPI.Lista(),
                tipo_tickets = new List<Tipo_Ticket>(), // await _servicioTipoTicketAPI.Lista()
                ticketPadre = await _servicioTicketAPI.Obtener(ticketPadreId)
            };
            return View(ticketNuevoViewModel);
        }




        public async Task<IActionResult> Merge(string departamentoId,string ticketId)
        {
            TicketMergeViewModel ticketMergeViewModel = new TicketMergeViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                familiaTicket = new Familia_Ticket(),
                tickets = await _servicioTicketAPI.Lista(departamentoId, "Abiertos")
            };
            return View(ticketMergeViewModel);
        }

        public async Task<IActionResult> Details(string ticketId)
        {
            TicketDetailsViewModel ticketDetailsViewModel = new TicketDetailsViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                familiaTicket = await _servicioTicketAPI.FamiliaTicket(ticketId),
                bitacoraTicket = await _servicioTicketAPI.BitacoraTicket(ticketId),
                //estados = await _servicioEstadoAPI.Estados()
            };
            return View(ticketDetailsViewModel);
        }

        public async Task<IActionResult> Reenviar(string ticketId)
        {
            TicketReenviarViewModel ticketReenviarViewModel = new TicketReenviarViewModel()
            {
                ticketPadre = await _servicioTicketAPI.Obtener(ticketId),
                ticketHijo = new Ticket(),
                prioridades = await _servicioPrioridadAPI.ListaHabilitado(),
                departamentos = new List<Departamento>(), //await _servicioDepartamentoAPI(),
                tipo_tickets = new List<Tipo_Ticket>(), //await _servicioTipoTicketAPI()
            };
            return View(ticketReenviarViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarTicket(Ticket ticket)
        {
            JObject respuesta;
            try
            {
                if (ticket.Ticket_Padre == null)
                {
                    respuesta = await _servicioTicketAPI.Guardar(ticket);
                    Console.WriteLine(respuesta.ToString());
                    if ((bool)respuesta["success"])
                    {
                        Console.WriteLine("La respuesta fue verdadera");
                        return RedirectToAction("Index", new { message = (string)respuesta["message"] });

                    }
                    else
                    {
                        Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                        return RedirectToAction("Ticket",(new { message = (string)respuesta["message"] }));
                    }
                }
                else
                {
                    respuesta = null;// await _servicioTicketAPI.Editar(Ticket);
                    if ((bool)respuesta["success"])
                    {
                        return RedirectToAction("Index", new { message = (string)respuesta["message"] });
                    }
                    else
                    {
                        return RedirectToAction("Prioridad", new { message = (string)respuesta["message"] });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        public IActionResult GuardarMerge()
        {
            return View();
        }

        public IActionResult GuardarBitacora()
        {
            return View();
        }
    }
}

