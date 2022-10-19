using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Ticket
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        [MaxLength(60)]
        [MinLength(3)]
        private string titulo { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [MinLength(3)]
        private string descripcion { get; set; } = string.Empty;
        [Required]
        private DateTime fecha_creacion { get; set; }
        [Required]
        private DateTime fecha_eliminacion { get; set; }
        [Required]
        private Estado Estado { get; set; }
        [Required]
        private Prioridad Prioridad { get; set; }
        [Required]
        private Tipo_Ticket Tipo_Ticket { get; set; }
        [Required]
        private HashSet<Votos_Ticket> Votos_Ticket { get; set; }
        private Familia_Ticket Familia_Ticket { get; set; }
        private Ticket Ticket_Padre { get; set; }
    }
}
