
using System;

namespace ServicesDeskUCABWS.Models
{
    public class Flujo_Aprobacion
    {
        private Guid Id { get; set; }
        private int OrdenAprobacion { get; set; }
        private Tipo_Cargo Tipo_Cargo { get; set; }
        private Tipo_Ticket Tipo_Ticket { get; set; }

    }
}
