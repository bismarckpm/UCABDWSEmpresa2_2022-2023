using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketNuevoDTO
    {
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public Guid usuario_id { get; set; }
        public Guid prioridad_id { get; set; }
        public Guid tipoTicket_id { get; set; } //-> con esto calculo el estado del ticket
        public Guid departamentoDestino_Id { get; set; }
    }
}
