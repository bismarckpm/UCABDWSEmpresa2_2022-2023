using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketNuevoDTO
    {
        public Guid Id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public Guid usuario_id { get; set; }
        public string estado_nombre { get; set; }
        public string prioridad_nombre { get; set; }
        public string tipoTicket_nombre { get; set; }
        public string departamentoSalida_nombre { get; set; }
        public string departamentoDestino_nombre { get; set; }

    }
}
