using System;
namespace ServicesDeskUCAB.Models
{
    public class FlujoAprobacion
    {
        public int FlujoAprobacionID { get; set; }
        public int OrdenAprobacion { get; set; }
        public int TipoCargoID { get; set; }
        public int TipoTicketID { get; set; }

        public TipoCargo TipoCargo { get; set; }
        public Tipo_Ticket TipoTicket { get; set; }
    }
}

