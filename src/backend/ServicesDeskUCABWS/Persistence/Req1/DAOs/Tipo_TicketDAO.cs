using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using System;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Persistence.Req1.DAOs
{
    public class Tipo_TicketDAO
    {
        // Inyeccion de dependencias DBcontext
        private readonly IDataContext _context;

        //
        public Tipo_TicketDAO(IDataContext context)
        {
            _context = context;
        }
        
        // Update Tipo Ticket
        public async Task<Tipo_Ticket> Edit([Bind("Id,nombre,descripcion,tipo,fecha_creacion,fecha_ult_edic,fecha_elim,Minimo_Aprobado")] Tipo_Ticket tipo_Ticket)
        {
            _context.Update(tipo_Ticket);
            await _context.SaveChangesAsync();
            return tipo_Ticket;
        }

        // Delete Tipo Ticket
        public async Task Delete(Guid id)

        {
            var tipo_Ticket = await _context.Tipos_Tickets.FindAsync(id);
            if (tipo_Ticket != null)
            {
                _context.Tipos_Tickets.Remove(tipo_Ticket);
            }

            await _context.SaveChangesAsync();

        }
    }
}
