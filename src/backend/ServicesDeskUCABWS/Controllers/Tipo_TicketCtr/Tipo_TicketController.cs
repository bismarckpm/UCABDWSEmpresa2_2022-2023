using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.CTipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.Controllers.Tipo_TicketCtr
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_TicketController : Controller
    {
        private readonly DataContext _context;
        private readonly ITipo_TicketDAO _ticketDAO;

        public Tipo_TicketController(ITipo_TicketDAO ticketDAO, DataContext context)
        {
            _context = context;
            _ticketDAO = ticketDAO;

        }

        // GET: api/Tipo_Ticket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlujoAprobacionDTO>>> GetTipos_Tickets()
        {
            //_Tipo_ticketDAO.ConsultaListaTickets();

            var tipo = _context.Tipos_Tickets.Join(_context.Flujos_Aprobaciones,
                p => p.Id,
                e => e.IdTicket,
                (p, e) => new FlujoAprobacionDTO()
                {
                    IdTipoTicket = p.Id,
                    nombreTipoTicket = p.nombre,
                    tipo = p.tipo,
                    IdTipoCargo = e.Tipo_Cargo.Id,
                    tipo_cargo = e.Tipo_Cargo.nombre
                }).ToListAsync();
            return await tipo;
        }

        // GET: api/Tipo_Ticket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo_Ticket>> GetTipo_Ticket(Guid id)
        {
            var tipo_Ticket = await _context.Tipos_Tickets.FindAsync(id);

            if (tipo_Ticket == null)
            {
                return NotFound();
            }

            return tipo_Ticket;
        }

        // PUT: api/Tipo_Ticket/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ApplicationResponse<Tipo_TicketDTOUpdate> EditarTipo_Ticket(Tipo_TicketDTOUpdate tipo_Ticket)
        {
            var response = _ticketDAO.ActualizarTipo_Ticket(tipo_Ticket);
            return response;
        }

        // POST: api/Tipo_Ticket
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ApplicationResponse<Tipo_Ticket> PostTipo_Ticket(Tipo_TicketDTOCreate tipo_TicketDTO)
        {
            var response = _ticketDAO.RegistroTipo_Ticket(tipo_TicketDTO);
            return response;
        }



        // DELETE: api/Tipo_Ticket/5
        /*[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo_Ticket(Guid id)
        {
            var tipo_Ticket = await _context.Tipos_Tickets.FindAsync(id);
            if (tipo_Ticket == null)
            {
                return NotFound();
            }

            _context.Tipos_Tickets.Remove(tipo_Ticket);
            await _context.SaveChangesAsync();

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
