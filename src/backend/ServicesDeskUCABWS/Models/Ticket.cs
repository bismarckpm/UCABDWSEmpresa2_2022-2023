using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_eliminacion { get; set; }
        public Estado Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        public Tipo_Ticket Tipo_Ticket { get; set; }
        public HashSet<Votos_Ticket> Votos_Ticket { get; set; }
    }
}
