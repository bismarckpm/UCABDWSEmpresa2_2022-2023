using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Entities
{
    public class Prioridad
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required, MaxLength(100), MinLength(4)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public string Estado { get; set; }
        [Required]
        public DateTime FechaDescripcion { get; set; }
        [Required]
        public DateTime FechaUltimaEdic { get; set; }
        
    }
}
