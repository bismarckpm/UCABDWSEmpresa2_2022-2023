using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Prioridad
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        private string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        private string descripcion { get; set; } = string.Empty;
        [Required]
        private DateTime fecha_descripcion { get; set; }
        [Required]
        private DateTime fecha_ultima_edic { get; set; }
    }
}
