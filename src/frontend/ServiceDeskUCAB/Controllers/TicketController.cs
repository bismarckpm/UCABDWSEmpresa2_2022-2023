using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models.DTO.TicketDTO;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios;
using ServiceDeskUCAB.ViewModel;
using ServicesDeskUCAB.Models;

namespace ServiceDeskUCAB.Controllers
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
            List<TicketBasicoDTO> lista = await _servicioTicketAPI.Lista(departamentoId, opcion);
            return View(lista);
        }

        public async Task<IActionResult> Ticket()
        {
            ViewBag.departamentoId = "ccacd411-1b46-4117-aa84-73ea64deac87";

            Departamento depa= new Departamento();
            depa.DepartamentoID = new Guid("ccacd411-1b46-4117-aa84-73ea64deac87");
            depa.Nombre = "Almacen";

            Tipo_Ticket tipoTi = new Tipo_Ticket();
            tipoTi.TipoTicketID = new Guid("172ce21d-b7dc-4537-9901-e0a29753644f");
            tipoTi.Nombre = "Solicitud";

            TicketNuevoViewModel ticketNuevoViewModel = new TicketNuevoViewModel
            {
                ticket = new TicketDTO(),
                prioridades = await _servicioPrioridadAPI.Lista(),
                departamentos = new List<Departamento>(), // await _servicioDepartamentoAPI.Lista(),
                tipo_tickets = new List<Tipo_Ticket>(), // await _servicioTipoTicketAPI.Lista()
            };
            ticketNuevoViewModel.ticket.empleado_id = Guid.Parse("172ce21d-b7dc-7537-0901-e0a29753644f"); //Token
            ticketNuevoViewModel.departamentos.Add(depa);
            ticketNuevoViewModel.tipo_tickets.Add(tipoTi);
            return View(ticketNuevoViewModel);
        }

        public async Task<IActionResult> Reenviar(string ticketPadre_Id)
        {
            ViewBag.departamentoId = "ccacd411-1b46-4117-aa84-73ea64deac87";

            Departamento depa1 = new Departamento();
            depa1.DepartamentoID = new Guid("ccacd411-1b46-4117-aa84-73ea64deac87");
            depa1.Nombre = "departamento 1";

            Departamento depa2 = new Departamento();
            depa2.DepartamentoID = new Guid("21674527-d5b9-4d18-8b6a-fde8d8718061");
            depa2.Nombre = "departamento 2";

            Tipo_Ticket tipoTi = new Tipo_Ticket();
            tipoTi.TipoTicketID = new Guid("172ce21d-b7dc-4537-9901-e0a29753644f");
            tipoTi.Nombre = "Solicitud";
            try
            {
                TicketReenviarDTOViewModel ticketReenviarViewModel = new TicketReenviarDTOViewModel()
                {
                    ticketPadre = await _servicioTicketAPI.Obtener(ticketPadre_Id),
                    ticket = new TicketReenviarDTO(),
                    prioridades = await _servicioPrioridadAPI.Lista(),
                    departamentos = new List<Departamento>(), // await _servicioDepartamentoAPI.Lista(),
                    tipo_tickets = new List<Tipo_Ticket>(), // await _servicioTipoTicketAPI.Lista()
                };
                ticketReenviarViewModel.ticket.ticketPadre_Id = Guid.Parse(ticketPadre_Id);
                ticketReenviarViewModel.ticket.titulo = ticketReenviarViewModel.ticketPadre.titulo;
                ticketReenviarViewModel.ticket.descripcion = ticketReenviarViewModel.ticketPadre.descripcion;
                ticketReenviarViewModel.ticket.empleado_id = Guid.Parse("172ce21d-b7dc-7537-0901-e0a29753644f"); //Token de usuario
                ticketReenviarViewModel.departamentos.Add(depa1);
                ticketReenviarViewModel.departamentos.Add(depa2);
                ticketReenviarViewModel.tipo_tickets.Add(tipoTi);
                return View(ticketReenviarViewModel);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return NoContent();
            
        }

        public async Task<IActionResult> Merge(string departamentoId,string ticketId)
        {
            FamiliaMergeDTOViewModel ticketMergeViewModel = new FamiliaMergeDTOViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                familiaTicket = new Familia_Ticket(),
                //tickets = await _servicioTicketAPI.Lista(departamentoId, "Abiertos")
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
                estados = new List<Estado>() //await _servicioEstadoAPI.Estados()
            };

            return View(ticketDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarTicket(TicketDTO ticket)
        {
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.Guardar(ticket);
                Console.WriteLine(respuesta.ToString());
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    return RedirectToAction("Index", new { departamentoId = "ccacd411-1b46-4117-aa84-73ea64deac87", opcion = "Abiertos", message = (string)respuesta["message"] });

                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    // Falta retornar a la misma vista sin recargar
                    return RedirectToAction("Ticket",(new { message = (string)respuesta["message"] }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarReenviar(TicketReenviarDTO ticket)
        {
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.GuardarReenviar(ticket);
                Console.WriteLine(respuesta.ToString());
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    // Falta la ruta buena de Index
                    return RedirectToAction("Index",new { departamentoId = "ccacd411-1b46-4117-aa84-73ea64deac87", opcion = "Abiertos", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    // Falta retornar a la misma vista sin recargar
                    return RedirectToAction("Reenviar", (new { ticketPadre_Id = ticket.ticketPadre_Id, message = (string)respuesta["message"] }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarMerge(FamiliaMergeDTO merge)
        {
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.GuardarMerge(merge);
                Console.WriteLine(respuesta.ToString());
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    // Falta la ruta buena de Index
                    return RedirectToAction("Index", new { message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    // Falta retornar a la misma vista sin recargar
                    return RedirectToAction("Ticket", (new { message = (string)respuesta["message"] }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Cancelar(string ticketId)
        {
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.Cancelar(ticketId);
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    return RedirectToAction("Index", new { departamentoId = "ccacd411-1b46-4117-aa84-73ea64deac87", opcion = "Abiertos", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    return RedirectToAction("Index", (new { message = (string)respuesta["message"] }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado(ActualizarDTO ticketId)
        {
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.CambiarEstado(ticketId);
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    return RedirectToAction("Index", new { departamentoId = "ccacd411-1b46-4117-aa84-73ea64deac87", opcion = "Abiertos", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    return RedirectToAction("Index", (new { message = (string)respuesta["message"] }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

    }
}

