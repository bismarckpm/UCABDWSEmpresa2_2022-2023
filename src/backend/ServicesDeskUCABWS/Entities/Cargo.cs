using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDeskUCABWS.Entities
{
    public class Cargo
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(100)]
        public string nombre_departamental { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_creacion { get; set; }

        
        public DateTime? fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public List<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
        [Required]
        public Departamento Departamento { get; set; }

        public Cargo(string nombre_departamenta, string descripcion)
        {
            id = Guid.NewGuid();
            nombre_departamental = nombre_departamenta;
            this.descripcion = descripcion;
            fecha_creacion = DateTime.UtcNow;
            fecha_ultima_edicion = DateTime.UtcNow; 
        }

        public Cargo()
        {

        }
    }
}
