using ServicesDeskUCABWS.Entities;
using System;
using System.Runtime.Serialization;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class VotoTicketDTO
    {
        public Guid Id { get; set; }
        public aprobado aprobado { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
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
