using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class BitacoraTicketDTO
    {
        public Guid ticket { get; set; }
        public Guid nuevoEstado { get; set; }
    }
}
