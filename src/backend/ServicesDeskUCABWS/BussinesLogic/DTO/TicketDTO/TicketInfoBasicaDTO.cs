using Microsoft.VisualBasic;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO
{
    public class TicketInfoBasicaDTO
    {
        public Guid Id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string empleado_correo { get; set; }
        public string prioridad_nombre { get; set; }
        public DateTime fecha_creacion { get; set; }
        public string tipoTicket_nombre { get; set; }
        public string estado_nombre { get; set; }
        public int? jerarquia { get; set; }
        public int? nro_cargo_actual { get; set; }

    }
}
