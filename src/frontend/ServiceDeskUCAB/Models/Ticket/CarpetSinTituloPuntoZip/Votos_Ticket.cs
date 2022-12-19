using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCAB.Models
{
    public class Votos_Ticket
    {
        public int Id { get; set; }
        public Aprobado Aprobado { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Usuario { get; set; }
        public Ticket Ticket { get; set; }
    }

    public enum Aprobado
    {
        [EnumMember(Value = "A")]
        aprobado,
        [EnumMember(Value = "D")]
        denegado,
        [EnumMember(Value = "EE")]
        en_espera,
    }
}

