using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;
using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;

namespace ServicesDeskUCABWS.BussinesLogic.Helpers
{
    public class TicketHelpers
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public TicketHelpers(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public void inicializarBitacora(TicketDTO nuevoTicketDTO)
        {
            nuevoTicketDTO.Bitacora_Tickets = new HashSet<Bitacora_Ticket>
            {
                crearNuevaBitacora(nuevoTicketDTO)
            };
        }

        public Bitacora_Ticket crearNuevaBitacora(TicketDTO nuevoTicket)
        {
            return new Bitacora_Ticket()
            {
                Id = Guid.NewGuid(),
                Estado = nuevoTicket.Estado,
                Ticket = _mapper.Map<Ticket>(nuevoTicket),
                Fecha_Inicio = new DateTime()
            };
        }

        public void inicializarFamiliaTicket(TicketDTO nuevoTicket)
        {   //PARA LOS TICKETS HERMANOS
            nuevoTicket.Familia_Ticket = new Familia_Ticket()
            {
                Id = Guid.NewGuid(),
                Lista_Ticket = new List<Ticket>()
            };
        }
    }
}
