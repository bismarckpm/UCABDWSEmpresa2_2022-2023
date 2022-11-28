using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
    public class Familia_Ticket
    {
        public int FamiliaTicketID { get; set; }
        public int TicketID { get; set; }
        public List<Ticket> ListaTicket { get; set; }

        public Ticket Ticket { get; set; }
    }
}

