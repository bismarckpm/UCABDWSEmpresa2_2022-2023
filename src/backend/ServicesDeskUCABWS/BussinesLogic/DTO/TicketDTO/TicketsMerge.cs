using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketsMerge
    {
        public TicketDTO ticketPrincipal { get; set; }
        public List<TicketDTO> tickets { get; set; }
    }
}
