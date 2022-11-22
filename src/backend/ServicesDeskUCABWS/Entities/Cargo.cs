using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Entities
{
    public class Cargo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre_departamental { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_creacion { get; set; }

        [Required]
        public DateTime fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public HashSet<Tipo_Cargo> Tipo_Cargo { get; set; }
        public Departamento Departamento { get; set; }
    }
}
