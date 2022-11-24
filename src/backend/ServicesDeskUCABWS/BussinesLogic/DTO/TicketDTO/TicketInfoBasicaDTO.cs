using Microsoft.VisualBasic;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO
{
    public class TicketInfoBasicaDTO
    {
        public Guid id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string empleado_correo { get; set; }
        public string prioridad_nombre { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string tipoTicket_nombre { get; set; }
        public string departamentoDestino_nombre { get; set; }
        public string estado_nombre { get; set; }
    }
}
