using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Entities
{
    public class Tipo_Cargo
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(150)]
        public string nombre { get; set; } = string.Empty;
        [Required]
        [StringLength(250)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string nivel_jerarquia { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_ult_edic { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        //public virtual List<Cargo> cargos { get; set; }
        public List<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
        public List<Cargo> Cargos_Asociados { get; set; }

        public Tipo_Cargo(string nombre, string descripcion, string nivel_jerarquia)
        {
            id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.nivel_jerarquia = nivel_jerarquia;
            fecha_creacion = DateTime.UtcNow;
            fecha_ult_edic = DateTime.UtcNow;
        }

        public Tipo_Cargo()
        {
        }
    }
}
