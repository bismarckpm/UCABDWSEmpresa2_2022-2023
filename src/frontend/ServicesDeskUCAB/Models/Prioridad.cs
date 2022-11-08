using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.Models
{
    public class Prioridad
    {
        [Required]
        public int ID { get; set; }

        [Required,MinLength(4),MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MinLength(4), MaxLength(100)]
        public string Descripcion { get; set; }

        [Required,MinLength(1),MaxLength(30)]
        public string Estado { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaDescripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaUltimaEdic { get; set; }
    }
}

