
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace ServicesDeskUCABWS.Models
{
    public class Grupo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_creacion { get; set; }

        [Required]
        public DateTime fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public HashSet<Departamento> Departamento { get; set; }
    }
}
