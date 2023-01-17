using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO
{
    public class TicketReenvioDTO
    {
        public TicketNuevoDTO solicitudTicket { get; set; }
        public Guid? ticketPapaId { get; set; }
    }
}
