using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCAB.Models
{
    public class Prioridad
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required,MinLength(4),MaxLength(100)]
        public string Descripcion { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public DateTime FechaDescripcion { get; set; }
        [Required]
        public DateTime FechaUltimaEdic { get; set; }
    }
    
}

