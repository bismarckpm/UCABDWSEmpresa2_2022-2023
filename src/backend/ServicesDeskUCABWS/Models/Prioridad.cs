using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Prioridad
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_descripcion { get; set; }
        [Required]
        public DateTime fecha_ultima_edic { get; set; }
    }
}
