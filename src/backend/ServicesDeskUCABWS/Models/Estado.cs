using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Estado
    {

        [Key]
        private Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        private string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(70)]
        [MinLength(3)]
        private string descripcion { get; set; } = string.Empty;
        [Required]
        private DateTime fecha_creacion { get; set; }
        [Required]
        private DateTime fecha_ultima_edic { get; set; }
        [Required]
        private Tipo_Estado Estado_Padre { get; set; }

    }
}
