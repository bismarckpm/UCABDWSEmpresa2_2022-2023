using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models
{
    public class Prioridad
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;

        public Prioridad(string nombre, string descripcion)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}
