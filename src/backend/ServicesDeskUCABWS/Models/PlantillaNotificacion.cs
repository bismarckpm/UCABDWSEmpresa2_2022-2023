using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Models
{
    public class PlantillaNotificacion
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        private string titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        private string descripcion { get; set; } = string.Empty;
        }
}
