using System;
using System.Collections.Generic;

namespace ServicesDeskUCAB.Models
{
    public class FamiliaTicket
    {
        public int FamiliaTicketID { get; set; }
        public int TicketID { get; set; }
        public ICollection<Ticket> ListaTicket { get; set; }

        public Ticket Ticket { get; set; }
    }
}

