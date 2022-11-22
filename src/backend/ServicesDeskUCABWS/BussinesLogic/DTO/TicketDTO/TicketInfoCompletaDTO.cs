using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO
{
    public class TicketInfoCompletaDTO
    {
        public Guid ticket_id { get; set; }
        public Guid ticketPadre_id { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_eliminacion { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string estado_nombre { get; set; }
        public string tipoTicket_nombre { get; set; }
        public string departamentoDestino_nombre { get; set; }
        public string prioridad_nombre { get; set; }
        public string empleado_correo { get; set; }
        // ?? public int numero_votos {get; set;} 
    }
}
