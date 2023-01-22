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
using ServicesDeskUCAB.Models;
using ServiceDeskUCAB.Models.TipoTicketsModels;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models.DTO.TicketDTO;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using Microsoft.AspNetCore.Authorization;
using ServiceDeskUCAB.Models.Response;

namespace ServiceDeskUCAB.Controllers
{

    [Authorize(Policy = "EmpleadoAccess")]
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
            List<TicketBasicoDTO> lista;
            var departamento= await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            if (!departamento.Success)
            {
                return View(new List<TicketBasicoDTO>());
            }
            if (opcion != "Enviados")
            {
                lista = await _servicioTicketAPI.Lista(departamento.Data.Id, opcion, idUsuario);
            }
            else
            {
                lista = await _servicioTicketAPI.TicketsEnviados(idUsuario);
            }
            return View(lista);
        }

        public async Task<IActionResult> Ticket()
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            var departamento = new ApplicationResponse<DepartamentoSearchDTO>();
            departamento = await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            if (departamento.Success == false)
            {
                return RedirectToAction("Index", new { opcion = "Abiertos", message = departamento.Message });
            }    
            
            TicketNuevoViewModel ticketNuevoViewModel = new TicketNuevoViewModel()
            {
                ticket = new TicketDTO(),
                prioridades = await _servicioPrioridadAPI.ListaHabilitado(),
                departamentos = await _servicioTicketAPI.Departamentos(idUsuario),
                tipo_tickets = await _servicioTicketAPI.TipoTickets(Guid.Parse(departamento.Data.Id))
            };
            ticketNuevoViewModel.ticket.empleado_id = new Guid(idUsuario);
            return View(ticketNuevoViewModel);
        }

        public async Task<IActionResult> Reenviar(string ticketPadre_Id)
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            var departamento = await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            if (departamento.Success == false)
            {
                return RedirectToAction("Index", new { opcion = "Abiertos", message = departamento.Message });
            }
            try
            {
                TicketReenviarDTOViewModel ticketReenviarViewModel = new TicketReenviarDTOViewModel()
                {
                    ticketPadre = await _servicioTicketAPI.Obtener(ticketPadre_Id),
                    ticket = new TicketReenviarDTO(),
                    prioridades = await _servicioPrioridadAPI.ListaHabilitado(),
                    departamentos = await _servicioTicketAPI.Departamentos(idUsuario),
                    tipo_tickets = await _servicioTicketAPI.TipoTickets(new Guid(departamento.Data.Id))
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
            var departamento = await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            if (departamento.Success == false)
            {
                return RedirectToAction("Index", new { opcion = "Abiertos", message = departamento.Message });
            }
            FamiliaMergeDTOViewModel ticketMergeViewModel = new FamiliaMergeDTOViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                tickets = await _servicioTicketAPI.Lista(departamento.Data.Id, "Mis-Tickets",idUsuario)
            };
            return View(ticketMergeViewModel);
        }

        public async Task<IActionResult> Details(string ticketId)
        {
            var idUsuario = User.Identities.First().Claims.ToList()[0].Value;
            var departamento = await _servicioTicketAPI.departamentoEmpleado(idUsuario);
            TicketDetailsViewModel ticketDetailsViewModel = new TicketDetailsViewModel()
            {
                ticket = await _servicioTicketAPI.Obtener(ticketId),
                familiaTicket = await _servicioTicketAPI.FamiliaTicket(ticketId),
                bitacoraTicket = await _servicioTicketAPI.BitacoraTicket(ticketId),
                estados = await _servicioTicketAPI.DepartamentoEstados(departamento.Data.Id)
            };
            ViewBag.responsable = idUsuario;
            ViewBag.usuarioCorreo = User.Identities.First().Claims.ToList()[1].Value;
            return View(ticketDetailsViewModel);
        }

        public async Task<IActionResult> TomarTicket(string ticketId)
        {
            TicketTomarDTO tomar= new TicketTomarDTO();
            tomar.empleadoId = User.Identities.First().Claims.ToList()[0].Value;
            tomar.ticketId = ticketId;
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.TomarTicket(tomar);
                Console.WriteLine(respuesta.ToString());
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    return RedirectToAction("Index", new { opcion = "Mis-Tickets", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    // Falta retornar a la misma vista sin recargar
                    return RedirectToAction("Index", new { opcion = "Abiertos", message = (string)respuesta["message"] });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
        }

        public async Task<IActionResult> Finalizar(string ticketId)
        {
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.Finalizar(ticketId);
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    return RedirectToAction("Index", new { opcion = "Mis-Tickets", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    return RedirectToAction("Index", (new { opcion = "Mis-Tickets", message = (string)respuesta["message"] }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return NoContent();
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
                    Console.WriteLine($"REENVIO: {(string)respuesta["message"]}");
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
        public async Task<IActionResult> GuardarMerge(Guid ticketId, IFormCollection formCollection)
        {
            var count = formCollection.Keys.Count;
            FamiliaMergeDTO merge = new FamiliaMergeDTO();
            merge.ticketPrincipalId = ticketId;
            merge.ticketsSecundariosId = new List<Guid>();
            for (var i = 0; i < count - 1; i++)
            {
                var element = formCollection[formCollection.Keys.ElementAt(i)];
                merge.ticketsSecundariosId.Add(new Guid(element));
            }
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.GuardarMerge(merge);
                //Console.WriteLine(respuesta.ToString());
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
        public async Task<IActionResult> CambiarEstado(string ticketId, string estadoId)
        {
            ActualizarDTO actualizar = new ActualizarDTO();
            actualizar.estadoId = estadoId;
            actualizar.ticketId = ticketId;
            JObject respuesta;
            try
            {
                respuesta = await _servicioTicketAPI.CambiarEstado(actualizar);
                if ((bool)respuesta["success"])
                {
                    Console.WriteLine("La respuesta fue verdadera");
                    return RedirectToAction("Index", new { opcion = "Mis-Tickets", message = (string)respuesta["message"] });
                }
                else
                {
                    Console.WriteLine("La respuesta fue falsa, porque hubo un error");
                    return RedirectToAction("Details", (new { ticketId = actualizar.ticketId, opcion = "Mis-Tickets", message = (string)respuesta["message"] }));
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

