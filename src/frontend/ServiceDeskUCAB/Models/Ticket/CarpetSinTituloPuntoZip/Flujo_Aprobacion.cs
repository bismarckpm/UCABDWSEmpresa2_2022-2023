using System;
namespace ServicesDeskUCAB.Models
{
    public class Flujo_Aprobacion
    {
        public int Flujo_AprobacionID { get; set; }
        public int OrdenAprobacion { get; set; }
        public int Tipo_CargoID { get; set; }
        public int TipoTicketID { get; set; }

        public Tipo_Cargo Tipo_Cargo { get; set; }
        public Tipo_Ticket TipoTicket { get; set; }
    }
}

