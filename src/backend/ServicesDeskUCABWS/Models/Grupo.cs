
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace ServicesDeskUCABWS.Models
{
    public class Grupo
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        private string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        private string descripcion { get; set; } = string.Empty;

        [Required]
        private DateTime fecha_creacion { get; set; }

        [Required]
        private DateTime fecha_ultima_edicion { get; set; }
        private DateTime? fecha_eliminacion { get; set; }
        private HashSet<Departamento> Departamento { get; set; }
    }
}
