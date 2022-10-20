
using System;

namespace ServicesDeskUCABWS.Models
{
    public class Flujo_Aprobacion
    {
        public Guid Id { get; set; }
        public int OrdenAprobacion { get; set; }
        public Tipo_Cargo Tipo_Cargo { get; set; }
        public Tipo_Ticket Tipo_Ticket { get; set; }

    }
}
