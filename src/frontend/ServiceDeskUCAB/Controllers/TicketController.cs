using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Servicios;
using ServiceDeskUCAB.ViewModel;
using ServiceDeskUCAB.Servicios;
using ServicesDeskUCAB.Models;
using ServiceDeskUCAB.Models.TipoTicketsModels;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models.DTO.TicketDTO;

namespace ServiceDeskUCAB.Controllers
{
    public class TicketController : Controller
    {
        private readonly IServicioTicketAPI _servicioTicketAPI;
        private readonly IServicioPrioridadAPI _servicioPrioridadAPI;

        public TicketController(IServicioPrioridadAPI servicioPrioridadAPI, IServicioTicketAPI servicioTicketAPI)
        {
            _servicioTicketAPI = servicioTicketAPI;
            _servicioPrioridadAPI = servicioPrioridadAPI;
        }

        public async Task<IActionResult> Index(string departamentoId,string opcion)
        {
            ViewBag.opcion = opcion;
            ViewBag.DepartamentoId = departamentoId;
            List<TicketBasicoDTO> lista = await _servicioTicketAPI.Lista(departamentoId, opcion);
            return View(lista);
        }

        public async Task<IActionResult> Ticket(string departamentoId)
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            ViewBag.DepartamentoId = departamentoId;
            TicketNuevoViewModel ticketNuevoViewModel = new TicketNuevoViewModel
            {
                ticket = new TicketDTO(),
                prioridades = await _servicioPrioridadAPI.Lista(),
                departamentos = await _servicioTicketAPI.Departamentos(idUsuario), //COLOCAR EL ID DEL USUARIO LOGUEADO MEDIANTE EL TOKEN
            };
            ticketNuevoViewModel.ticket.empleado_id = new Guid(idUsuario); //Token
            return View(ticketNuevoViewModel);
        }

        public async Task<IActionResult> Reenviar(string ticketPadre_Id, string departamentoId)
        {
            ViewBag.DepartamentoId = departamentoId;
            try
            {
                TicketReenviarDTOViewModel ticketReenviarViewModel = new TicketReenviarDTOViewModel()
                {
                    ticketPadre = await _servicioTicketAPI.Obtener(ticketPadre_Id),
                    ticket = new TicketReenviarDTO(),
                    prioridades = await _servicioPrioridadAPI.Lista(),
                    departamentos = new List<Departament>(), // await _servicioDepartamentoAPI.Lista(),
                    tipo_tickets = new List<Tipo>(), // await _servicioTipoTicketAPI.Lista()
                };
                ticketReenviarViewModel.ticket.ticketPadre_Id = Guid.Parse(ticketPadre_Id);
                ticketReenviarViewModel.ticket.titulo = ticketReenviarViewModel.ticketPadre.titulo;
                ticketReenviarViewModel.ticket.descripcion = ticketReenviarViewModel.ticketPadre.descripcion;
                ticketReenviarViewModel.ticket.empleado_id = Guid.Parse("172ce21d-b7dc-7537-0901-e0a29753644f"); //Token de usuario
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
                estados = new List<Estado>() //await _servicioEstadoAPI.Estados()
            };

            return View(ticketDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarTicket(TicketDTO ticket, string departamentoId)
        {
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.Guardar(ticket);
                Console.WriteLine(respuesta.ToString());
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    return RedirectToAction("Index", new { departamentoId = departamentoId, opcion = "Abiertos", message = (string)respuesta["message"] });

                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    // Falta retornar a la misma vista sin recargar
                    return RedirectToAction("Ticket",(new { departamentoId = departamentoId, message = (string)respuesta["message"] }));
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
        public async Task<IActionResult> GuardarMerge(Guid ticketId,Guid[] familia )
        {
            FamiliaMergeDTO merge = new FamiliaMergeDTO();
            merge.ticketPadre_Id = ticketId;
            merge.tickets = new List<Guid>();
            int i = 0;
            foreach(Guid item in familia)
            {
                merge.tickets[i] = item;
                i++;
            }
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

