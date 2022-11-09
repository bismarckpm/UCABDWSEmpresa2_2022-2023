
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Entities
{
    public class Tipo_Estado
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string descripcion { get; set; } = string.Empty;

        public HashSet<Etiqueta> Etiqueta { get; set; }

        public PlantillaNotificacion PlantillaNotificacion { get; set; }

        public List<Estado> ListaEstadosDerivados { get; set; }

        public Tipo_Estado(string nombre, string descripcion)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;

        }

        public Tipo_Estado()
        {

        }
    }
}
