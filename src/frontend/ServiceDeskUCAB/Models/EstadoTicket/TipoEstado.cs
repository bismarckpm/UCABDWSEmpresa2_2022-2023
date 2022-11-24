using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models.EstadoTicket

{
    public class TipoEstado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Etiqueta> Etiqueta { get; set; }
        public bool Permiso { get; set; }
        public TipoEstado()
        {
            Id = Guid.Empty;
            Nombre = null;
            Descripcion = null;
            Etiqueta = null;
        }

        public TipoEstado(string nombre, string descripcion, List<Etiqueta> etiqueta)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Etiqueta = etiqueta;
        }
    }
}