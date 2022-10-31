using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;


namespace ServicesDeskUCABWS.Controllers
{
   
        [Route("Tipo_Ticket")]
        [ApiController]
        public class Tipo_TicketController : ControllerBase
        {

            private readonly ITipo_TicketDAO _TipoTicket;
            private readonly IMapper _mapper;

            private readonly DataContext _TipoTicketContext;


            //CONSTRUCTOR
            public Tipo_TicketController(ITipo_TicketDAO TipoTicket, IMapper mapper)
            {
                _mapper = mapper;
                _TipoTicket = TipoTicket;

            }
            [HttpGet]
            [Route("Consulta/")]
            public IEnumerable<Tipo_TicketDTO> ConsultarTipoTicketCtrl()
            {

                var tipo = _TipoTicket.ConsultarTipoTicket();
                return tipo;

            }

            [HttpGet]
            [Route("Consulta/(\"{id}\")")]
            public async Task<ActionResult<Tipo_Ticket>> ConsultarTipoTicketGuid(Guid id)
            {
                var tipo = await _TipoTicket.ConsultarTipoTicketGUID(id);


                return tipo;
            }



            /* public async Task<ActionResult<Tipo_Ticket>> GetByGuid(String nombre)
             {
                 var ticket = await _TipoTicket.ConsultarTipoTicketGUID(nombre);


                 return ticket;
             }*/

            /* public Tipo_TicketController(IDataContext context)
             {
                 _context = context;
                 tipo_TicketDAO = new Tipo_TicketDAO(context);
             }

             // GET: Tipo_Ticket/Edit/EndPoint Se usara despues para el front
             public async Task<IActionResult> Edit(Guid? id)
             {
                 if (id == null || _context.Tipos_Tickets == null)
                 {
                     return NotFound();
                 }

                 var tipo_Ticket = await _context.Tipos_Tickets.FindAsync(id);
                 if (tipo_Ticket == null)
                 {
                     return NotFound();
                 }
                 return View(tipo_Ticket);
             }

             // POST: Tipo_Ticket/Edit/Update Tipo Ticket
             [HttpPost]
             [ValidateAntiForgeryToken]
             public async Task<IActionResult> Edit(Guid id, [Bind("Id,nombre,descripcion,tipo,fecha_creacion,fecha_ult_edic,fecha_elim,Minimo_Aprobado")] Tipo_Ticket tipo_Ticket)
             {
                 if (id != tipo_Ticket.Id)
                 {
                     return NotFound();
                 }

                 if (ModelState.IsValid)
                 {
                     try
                     {
                         await tipo_TicketDAO.Edit(tipo_Ticket);
                     }
                     catch (DbUpdateConcurrencyException)
                     {
                         if (!Tipo_TicketExists(tipo_Ticket.Id))
                         {
                             return NotFound();
                         }
                         else
                         {
                             throw;
                         }
                     }
                     return RedirectToAction(nameof(Index));
                 }
                 return View(tipo_Ticket);
             }

             // GET: Tipo_Ticket/Delete/EndPoint Se usara despues para el front
             public async Task<IActionResult> Delete(Guid? id)
             {
                 if (id == null || _context.Tipos_Tickets == null)
                 {
                     return NotFound();
                 }

                 var tipo_Ticket = await _context.Tipos_Tickets
                     .FirstOrDefaultAsync(m => m.Id == id);
                 if (tipo_Ticket == null)
                 {
                     return NotFound();
                 }

                 return View(tipo_Ticket);
             }

             // POST: Tipo_Ticket/Delete/Controlador
             [HttpPost, ActionName("Delete")]
             [ValidateAntiForgeryToken]
             public async Task<IActionResult> DeleteConfirmed(Guid id)
             {
                 if (_context.Tipos_Tickets == null)
                 {
                     return Problem("Entity set 'DataContext.Tipos_Tickets'  is null.");
                 }
                 await tipo_TicketDAO.Delete(id);
                 return RedirectToAction(nameof(Index));
             }

             private bool Tipo_TicketExists(Guid id)
             {
               return _context.Tipos_Tickets.Any(e => e.Id == id);
             }*/
        }
    }
