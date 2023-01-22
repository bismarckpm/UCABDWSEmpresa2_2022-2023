using System;
namespace ServiceDeskUCAB.Models
{
	public class TicketBasicoDTO
    {
        public Guid Id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string empleado_correo { get; set; }
        public string encargado_correo { get; set; }
        public string prioridad_nombre { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public string tipoTicket_nombre { get; set; }
        public string estado_nombre { get; set; }
        public Guid? ticket_padre { get; set; }
    }
}

