using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServiceDeskUCAB.Models
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

        /*public Votos_Ticket(Empleado empleado, Ticket ticket)
        {
            this.Id = new Guid();
            this.voto = "pendiente";
            this.Empleado = empleado;
            this.Ticket = ticket;

        }*/
    }


    public enum aprobado
    {
        [EnumMember(Value = "A")]
        aprobado,
        [EnumMember(Value = "D")]
        denegado,
        [EnumMember(Value = "EE")]
        en_espera,
    }

}
