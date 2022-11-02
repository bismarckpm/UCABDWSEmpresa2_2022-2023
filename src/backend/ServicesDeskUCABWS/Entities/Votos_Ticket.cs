using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCABWS.Entities
{
    public class Votos_Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public aprobado aprobado { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
        public Usuario Usuario { get; set; }
        public Ticket Ticket { get; set; }
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
