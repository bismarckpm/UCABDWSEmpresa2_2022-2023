using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Estado
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(70)]
        [MinLength(3)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_ultima_edic { get; set; }

    }
}
