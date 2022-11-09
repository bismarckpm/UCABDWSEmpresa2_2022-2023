using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Entities
{
    public class PlantillaNotificacion
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(3000)]
        public string descripcion { get; set; } = string.Empty;

    }

}
