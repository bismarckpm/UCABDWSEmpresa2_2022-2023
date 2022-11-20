using System;
using System.Collections.Generic;

namespace ServicesDeskUCAB.Models
{
    public class Empleado : Usuario
    {
        public int CargoID { get; set; }
        public ICollection<Votos_Ticket> VotosTicket { get; set; }

        public Cargo Cargo { get; set; }
    }
}

