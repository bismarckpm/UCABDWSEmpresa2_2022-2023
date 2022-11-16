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
        public string nombre { get; set; }
        [Required,MinLength(4),MaxLength(100)]
        public string descripcion { get; set; }
        [Required]
        public string estado { get; set; }
        [Required]
        public DateTime fechaDescripcion { get; set; }
        [Required]
        public DateTime fechaUltimaEdic { get; set; }
    }
    
}

