using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO
{
    public class TicketBitacorasDTO
    {
        public Guid Id { get; set; }
        public string estado_nombre { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
    }
}
