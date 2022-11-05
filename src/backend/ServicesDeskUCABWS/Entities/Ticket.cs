using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDeskUCABWS.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(60)]
        [MinLength(3)]
        public string titulo { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [MinLength(3)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_eliminacion { get; set; }
        
        [ForeignKey("FK_Estado")]
        public int? IDEstado { get; set; }
        
        public Estado Estado { get; set; }
        [Required]
        public Prioridad Prioridad { get; set; }
        [Required]
        public Tipo_Ticket Tipo_Ticket { get; set; }
        [Required]
        public HashSet<Votos_Ticket> Votos_Ticket { get; set; }
        public Departamento Departamento_Destino { get; set; }
        public Familia_Ticket Familia_Ticket { get; set; }  
        public Ticket Ticket_Padre { get; set; }
        public HashSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }
    }
}
