using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketsMergeDTO
    {
        public Guid ticketPrincipal { get; set; }
        public List<Guid> ticketsSecundarios { get; set; }
        //A LOS TICKETS SECUNDARIOS SE LE TIENE QUE MODIFICAR LA FECHA DE ELIMINACIÓN, Y EL ESTADO A ELIMINADO
    }
}
