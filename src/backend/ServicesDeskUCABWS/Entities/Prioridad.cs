using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Entities
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

        public Prioridad(string nombre, string descripcion)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
            fecha_descripcion = DateTime.UtcNow;
            fecha_ultima_edic = DateTime.UtcNow;
        }
    }
}
