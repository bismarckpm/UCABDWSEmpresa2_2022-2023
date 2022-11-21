using System.Collections.Generic;

namespace ServicesDeskUCABWS.Entities
{
    public class Empleado : Usuario
    {
        public List<Ticket> Lista_Ticket { get; set; }
        public Cargo Cargo { get; set; }
        public HashSet<Votos_Ticket> Votos_Ticket { get; set; }

    }

}
