using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Bitacora_Ticket
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        private DateTime Fecha_Inicio { get; set; }
        private DateTime Fecha_Fin { get; set; }
    }
}
