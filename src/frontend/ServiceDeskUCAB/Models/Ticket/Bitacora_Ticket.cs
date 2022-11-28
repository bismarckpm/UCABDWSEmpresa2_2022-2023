using System;
namespace ServiceDeskUCAB.Models
{
    public class Bitacora_Ticket
    {
        public int BitacoraTicketID { get; set; }
        public int TicketID { get; set; }
        public Estado Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public Ticket Ticket { get; set; }
    }
}

