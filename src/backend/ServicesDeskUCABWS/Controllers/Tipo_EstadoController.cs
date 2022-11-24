using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.Controllers
{
    public class Tipo_EstadoController : Controller
    {
        private readonly DataContext _context;

        public Tipo_EstadoController(DataContext context)
        {
            _context = context;
        }

        // GET: Tipo_Estado
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tipos_Estados.ToListAsync());
        }

        // GET: Tipo_Estado/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Tipos_Estados == null)
            {
                return NotFound();
            }

            var tipo_Estado = await _context.Tipos_Estados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo_Estado == null)
            {
                return NotFound();
            }

            return View(tipo_Estado);
        }

        // GET: Tipo_Estado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Estado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,descripcion")] Tipo_Estado tipo_Estado)
        {
            if (ModelState.IsValid)
            {
                tipo_Estado.Id = Guid.NewGuid();
                _context.Add(tipo_Estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_Estado);
        }

        // GET: Tipo_Estado/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Tipos_Estados == null)
            {
                return NotFound();
            }

            var tipo_Estado = await _context.Tipos_Estados.FindAsync(id);
            if (tipo_Estado == null)
            {
                return NotFound();
            }
            return View(tipo_Estado);
        }

        // POST: Tipo_Estado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,nombre,descripcion")] Tipo_Estado tipo_Estado)
        {
            if (id != tipo_Estado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipo_EstadoExists(tipo_Estado.Id))
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
            return View(tipo_Estado);
        }

        // GET: Tipo_Estado/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Tipos_Estados == null)
            {
                return NotFound();
            }

            var tipo_Estado = await _context.Tipos_Estados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo_Estado == null)
            {
                return NotFound();
            }

            return View(tipo_Estado);
        }

        // POST: Tipo_Estado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tipos_Estados == null)
            {
                return Problem("Entity set 'DataContext.Tipos_Estados'  is null.");
            }
            var tipo_Estado = await _context.Tipos_Estados.FindAsync(id);
            if (tipo_Estado != null)
            {
                _context.Tipos_Estados.Remove(tipo_Estado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipo_EstadoExists(Guid id)
        {
          return _context.Tipos_Estados.Any(e => e.Id == id);
        }
    }
}
