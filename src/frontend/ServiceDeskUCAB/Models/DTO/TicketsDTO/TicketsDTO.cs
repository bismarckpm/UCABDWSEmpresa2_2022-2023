
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServiceDeskUCAB.Models.DTO.TicketsDTO
{
    public class TicketCreateDTO
    {

        [Required]
        [MaxLength(1000)]
        [MinLength(3)]
        public string titulo { get; set; } = string.Empty;
        [Required]
        [MaxLength(4000)]
        [MinLength(3)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public string Prioridad { get; set; }
        [Required]
        public string Tipo_Ticket { get; set; }
        [Required]
        public string Departamento_Destino { get; set; }
        public string Emisor { get; set; }
    }
}
