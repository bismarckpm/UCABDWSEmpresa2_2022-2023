using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketPaternoDTO
    {
        public Guid ticketPadre { get; set; }
        public TicketNuevoDTO ticketHijo { get; set; }
    }
}
