using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime? fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public Guid? id_tipo { get; set; }

        [ForeignKey("id_tipo")]
        public Tipo_Cargo tipo { get; set; }
    }
}
