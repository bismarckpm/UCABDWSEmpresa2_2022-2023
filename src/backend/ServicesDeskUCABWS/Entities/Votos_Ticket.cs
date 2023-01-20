using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCABWS.Entities
{
    public class Votos_Ticket
    {
        public Guid IdUsuario { get; set; }
        public Guid IdTicket { get; set; }
        public string voto { get; set; }
        public string comentario { get; set; }
        public DateTime? fecha { get; set; }

        public int? Turno { get; set; }
        public Empleado Empleado { get; set; }
        public Ticket Ticket { get; set; }

        
    }
}
