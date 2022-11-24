
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Entities
{
    public class Tipo_Estado
    {
        public Tipo_Estado()
        {
            this.etiquetaTipoEstado = new HashSet<EtiquetaTipoEstado>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string descripcion { get; set; }

        public HashSet<EtiquetaTipoEstado> etiquetaTipoEstado { get; set; }
        public Boolean permiso { get; set; }

        public Tipo_Estado(string nombre, string descripcion)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;

        }

    }
}
