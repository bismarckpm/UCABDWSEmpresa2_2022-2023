using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models
{
    public class Empleado : Usuario
    {
        private List<Ticket> Lista_Ticket { get; set; }
        private Cargo Cargo { get; set; }
        private HashSet<Votos_Ticket> Votos_Ticket { get; set; }
    
    }

}
