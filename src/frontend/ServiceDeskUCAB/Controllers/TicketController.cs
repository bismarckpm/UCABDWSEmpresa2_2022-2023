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
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;

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

        public async Task<IActionResult> Index(string opcion)
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            ViewBag.opcion = opcion;
            DepartamentoSearchDTO departamento= await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            List<TicketBasicoDTO> lista = await _servicioTicketAPI.Lista(departamento.Id, opcion);
            return View(lista);
        }

        public async Task<IActionResult> Ticket()
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            TicketNuevoViewModel ticketNuevoViewModel = new TicketNuevoViewModel
            {
                ticket = new TicketDTO(),
                prioridades = await _servicioPrioridadAPI.ListaHabilitado(),
                departamentos = await _servicioTicketAPI.Departamentos(idUsuario)
            };
            ticketNuevoViewModel.ticket.empleado_id = new Guid(idUsuario);
            return View(ticketNuevoViewModel);
        }

        public async Task<IActionResult> Reenviar(string ticketPadre_Id)
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            DepartamentoSearchDTO departamento = await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            try
            {
                TicketReenviarDTOViewModel ticketReenviarViewModel = new TicketReenviarDTOViewModel()
                {
                    ticketPadre = await _servicioTicketAPI.Obtener(ticketPadre_Id),
                    ticket = new TicketReenviarDTO(),
                    prioridades = await _servicioPrioridadAPI.ListaHabilitado(),
                    departamentos = await _servicioTicketAPI.Departamentos(idUsuario),
                    tipo_tickets = await _servicioTicketAPI.TipoTickets(new Guid(departamento.Id))
                };
                ticketReenviarViewModel.ticket.ticketPadre_Id = Guid.Parse(ticketPadre_Id);
                ticketReenviarViewModel.ticket.titulo = ticketReenviarViewModel.ticketPadre.titulo;
                ticketReenviarViewModel.ticket.descripcion = ticketReenviarViewModel.ticketPadre.descripcion;
                ticketReenviarViewModel.ticket.empleado_id = new Guid(idUsuario); //Token de usuario
                return View(ticketReenviarViewModel);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return NoContent();
            
        }

        public async Task<IActionResult> Merge(string ticketId)
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            DepartamentoSearchDTO departamento = await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            FamiliaMergeDTOViewModel ticketMergeViewModel = new FamiliaMergeDTOViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                tickets = await _servicioTicketAPI.Lista(departamento.Id, "Abiertos")
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
                    return RedirectToAction("Index", new {opcion = "Abiertos", message = (string)respuesta["message"] });

                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    // Falta retornar a la misma vista sin recargar
                    return RedirectToAction("Ticket",(new {message = (string)respuesta["message"] }));
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
                    return RedirectToAction("Index",new {opcion = "Abiertos", message = (string)respuesta["message"] });
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
        public async Task<IActionResult> GuardarMerge(Guid ticketId )
        {
            FamiliaMergeDTO merge = new FamiliaMergeDTO();
            /*merge.ticketPadre_Id = ticketId;
            merge.tickets = new List<Guid>();
            int i = 0;
            foreach(Guid item in familia)
            {
                merge.tickets[i] = item;
                i++;
            }*/
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.GuardarMerge(merge);
                Console.WriteLine(respuesta.ToString());
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    // Falta la ruta buena de Index
                    return RedirectToAction("Index", new { opcion = "Abiertos", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    // Falta retornar a la misma vista sin recargar
                    return RedirectToAction("Merge", (new { ticketId= ticketId , message = (string)respuesta["message"] }));
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
                    return RedirectToAction("Index", new {opcion = "Abiertos", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    return RedirectToAction("Index", (new { opcion = "Abiertos", message = (string)respuesta["message"] }));
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
                    return RedirectToAction("Index", new { opcion = "Abiertos", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    return RedirectToAction("Details", (new { ticketId = ticketId, opcion = "Abiertos", message = (string)respuesta["message"] }));
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

