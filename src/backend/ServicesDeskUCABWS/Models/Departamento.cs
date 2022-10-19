using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Models
{
    public class Departamento
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
        private HashSet<Tipo_Ticket> Tipo_Ticket { get; set; }
        private HashSet<Cargo> Cargo { get; set; }
        private Grupo Grupo { get; set; }
        private HashSet<Estado> Estado { get; set; }
    }
}
