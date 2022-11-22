using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Entities
{
    public class Etiqueta
    {
        public Etiqueta()
        {
            this.etiquetaTipoEstado = new HashSet<EtiquetaTipoEstado>();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; } = string.Empty;

        public HashSet<EtiquetaTipoEstado> etiquetaTipoEstado { get; set; }

    }
}
