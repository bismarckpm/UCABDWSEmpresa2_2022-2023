using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCAB.Models
{
    public class Prioridad
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required,MinLength(4),MaxLength(100)]
        public string descripcion { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public DateTime fecha_descripcion { get; set; }
        [Required]
        public DateTime fecha_ultima_edic { get; set; }
    }
    
}

