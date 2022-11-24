using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using ServiceDeskUCAB.Models.TipoTicketsModels;

namespace ServiceDeskUCAB.Models.DTO
{
    public class Cargo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string nombre_departamental { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_creacion { get; set; }

        [Required]
        public DateTime fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        [Required]
        public TipoCargo Tipo_Cargo { get; set; }
        [Required]
        public Departament Departamento { get; set; }

        public Cargo(string nombre_departamenta, string descripcion)
        {
            Id = Guid.NewGuid();
            nombre_departamental = nombre_departamenta;
            this.descripcion = descripcion;
            fecha_creacion = DateTime.UtcNow;
            fecha_ultima_edicion = fecha_ultima_edicion;
        }

        public Cargo()
        {

        }
    }
}
