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

        public TicketController(IServicioPrioridadAPI servicioPrioridadAPI, IServicioTicketAPI servicioTicketAPI/*, IServicioTipoTicketAPI servicioTipoTicketAPI, IServicioDepartamento servicioDepartamento*/)
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
            Departamento depa= new Departamento();
            depa.DepartamentoID = new Guid("CCACD411-1B46-4117-AA84-73EA64DEAC87");
            depa.Nombre = "Almacen";

            Tipo_Ticket tipoTi = new Tipo_Ticket();
            tipoTi.TipoTicketID = new Guid("172CE21D-B7DC-4537-9901-E0A29753644F");
            tipoTi.Nombre = "Solicitud";

            TicketNuevoViewModel ticketNuevoViewModel = new TicketNuevoViewModel
            {
                ticket = new CrearTicket(),
                prioridades = await _servicioPrioridadAPI.Lista(),
                departamentos = new List<Departamento>(), // await _servicioDepartamentoAPI.Lista(),
                tipo_tickets = new List<Tipo_Ticket>(), // await _servicioTipoTicketAPI.Lista()
                ticketPadre = await _servicioTicketAPI.Obtener(ticketPadreId)
            };
            ticketNuevoViewModel.departamentos.Add(depa);
            ticketNuevoViewModel.tipo_tickets.Add(tipoTi);
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

        [HttpPost]
        public async Task<IActionResult> GuardarTicket(CrearTicket ticket)
        {
            ticket.empleado_id = new Guid("172ce21d-b7dc-7537-0901-e0a29753644f");
            JObject respuesta;
            try
            {
                if (ticket.ticketPadre_Id == Guid.Empty)
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

                // Falta ticket reenviado
                /*
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
                */
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

