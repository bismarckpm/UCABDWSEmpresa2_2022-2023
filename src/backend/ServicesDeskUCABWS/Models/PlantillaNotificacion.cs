using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Models
{
    public class PlantillaNotificacion
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string descripcion { get; set; } = string.Empty;
        }
}
