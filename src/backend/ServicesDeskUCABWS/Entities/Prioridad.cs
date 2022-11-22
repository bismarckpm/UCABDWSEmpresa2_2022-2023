using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Entities
{
    public class Prioridad
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string nombre { get; set; } = string.Empty;
        [Required, MinLength(4), MaxLength(100)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public string estado { get; set; }
        [Required]
        public DateTime fecha_descripcion { get; set; }
        [Required]
        public DateTime fecha_ultima_edic { get; set; }
    }
}
