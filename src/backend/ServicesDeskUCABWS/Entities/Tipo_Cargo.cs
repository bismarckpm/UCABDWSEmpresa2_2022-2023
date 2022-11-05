using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Entities
{
    public class Tipo_Cargo
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
        [StringLength(20)]
        public string nivel_jerarquia { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ult_edic { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
       // public HashSet<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
    }
}
