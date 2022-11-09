using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
namespace ServicesDeskUCABWS.Controllers.Votos_TicketCtr
{
    public class Votos_TicketController : Controller
    {
        private readonly DataContext _context;

        public Votos_TicketController(DataContext context)
        {
            _context = context;
        }

        // GET: Votos_Ticket
        public async Task<IActionResult> Index()
        {
            return View(await _context.Votos_Tickets.ToListAsync());
        }

        // GET: Votos_Ticket/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Votos_Tickets == null)
            {
                return NotFound();
            }

            var votos_Ticket = await _context.Votos_Tickets
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (votos_Ticket == null)
            {
                return NotFound();
            }

            return View(votos_Ticket);
        }

        // GET: Votos_Ticket/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Votos_Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdTicket,voto,comentario,fecha")] Votos_Ticket votos_Ticket)
        {
            if (ModelState.IsValid)
            {
                votos_Ticket.IdUsuario = Guid.NewGuid();
                _context.Add(votos_Ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(votos_Ticket);
        }

        // GET: Votos_Ticket/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Votos_Tickets == null)
            {
                return NotFound();
            }

            var votos_Ticket = await _context.Votos_Tickets.FindAsync(id);
            if (votos_Ticket == null)
            {
                return NotFound();
            }
            return View(votos_Ticket);
        }

        // POST: Votos_Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdUsuario,IdTicket,voto,comentario,fecha")] Votos_Ticket votos_Ticket)
        {
            if (id != votos_Ticket.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(votos_Ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Votos_TicketExists(votos_Ticket.IdUsuario))
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
            return View(votos_Ticket);
        }

        // GET: Votos_Ticket/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Votos_Tickets == null)
            {
                return NotFound();
            }

            var votos_Ticket = await _context.Votos_Tickets
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (votos_Ticket == null)
            {
                return NotFound();
            }

            return View(votos_Ticket);
        }

        // POST: Votos_Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Votos_Tickets == null)
            {
                return Problem("Entity set 'DataContext.Votos_Tickets'  is null.");
            }
            var votos_Ticket = await _context.Votos_Tickets.FindAsync(id);
            if (votos_Ticket != null)
            {
                _context.Votos_Tickets.Remove(votos_Ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Votos_TicketExists(Guid id)
        {
            return _context.Votos_Tickets.Any(e => e.IdUsuario == id);
        }
    }
}
