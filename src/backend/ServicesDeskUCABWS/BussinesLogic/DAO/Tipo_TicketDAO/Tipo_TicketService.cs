using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO
{
    public class Tipo_TicketService : ITipo_TicketDAO
    {
        private readonly DataContext _TipoTicketContext;
        private readonly IMapper _mapper;

        //CONSTRUCTOR
        public Tipo_TicketService(DataContext TipoContext, IMapper mapper)
        {
            _TipoTicketContext = TipoContext;
            _mapper = mapper;
        }

        public IEnumerable<Tipo_TicketDTO> ConsultarTipoTicket()
        {
            var tipo = _TipoTicketContext.Tipos_Tickets
                .Include(dep => dep.Departamento)
                .Include(fa => fa.Flujo_Aprobacion)
                .ThenInclude(fb => fb.Tipo_Cargo)
                .ToList();
            var tipo_tickets = _mapper.Map<HashSet<Tipo_TicketDTO>>(tipo);
            return (IEnumerable<Tipo_TicketDTO>)tipo_tickets;
        }

        /*public async Task<Tipo_Ticket?> ConsultarTipoTicketGUID(Guid id)
        {
            return await _TipoTicketContext.Tipos_Tickets.FindAsync(id);



        }*/

        public Tipo_Ticket ConsultarTipoTicketGUID(Guid id)
        {
            var data = _TipoTicketContext.Tipos_Tickets.Include(p => p.Departamento).Include(fa => fa.Flujo_Aprobacion).Where(p => p.Id == id).Single();
            return data;
        }


        public Boolean EliminarTipoTicket(Guid id)
        {
            

                _TipoTicketContext.Tipos_Tickets.Remove(_TipoTicketContext.Tipos_Tickets.Find(id));
                _TipoTicketContext.SaveChanges();
                return true;
        }
        /*public IEnumerable<Tipo_Ticket> ConsultarNombreTipoTicket(String nombre)
        {
            var tipo = _TipoTicketContext.Tipos_Tickets
                .Include(dep => dep.Departamento)
                .Include(fa => fa.Flujo_Aprobacion)
                .ThenInclude(fb => fb.Tipo_Cargo).Where(p => p.nombre == nombre).Single();

            return (IEnumerable<Tipo_Ticket>)tipo;

        }
       */
    }
}
