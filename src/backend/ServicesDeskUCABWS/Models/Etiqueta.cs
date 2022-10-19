using ProyectD.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Models
{
    public class Etiqueta
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        private string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        private string descripcion { get; set; } = string.Empty;

    }
}
