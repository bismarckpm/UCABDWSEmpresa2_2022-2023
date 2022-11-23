using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketsMergeDTO
    {
        public Guid ticketPrincipalId { get; set; }
        public List<Guid> ticketsSecundariosId { get; set; }
        //A LOS TICKETS SECUNDARIOS SE LE TIENE QUE MODIFICAR LA FECHA DE ELIMINACIÓN, Y EL ESTADO A ELIMINADO
    }
}
