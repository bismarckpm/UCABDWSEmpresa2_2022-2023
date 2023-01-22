using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketDTO
    {
        public Guid Id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public Departamento Departamento_Destino { get; set; }
        public Estado Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        public Tipo_Ticket Tipo_Ticket { get; set; }
        public HashSet<Votos_Ticket>? Votos_Ticket { get; set; }
        public Familia_Ticket Familia_Ticket { get; set; }
        public Ticket? Ticket_Padre { get; set; }
        public Empleado Emisor { get; set; }
        public Empleado? Responsable { get; set; }
        public Guid? ResponsableId { get; set; }
        public HashSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public int? nro_cargo_actual { get; set; }

    }
}
