using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Persistence.Entities
{
    public class Bitacora_Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Estado Estado { get; set; }
        [Required]
        public Ticket Ticket { get; set; }
        [Required]
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }

    }
}
