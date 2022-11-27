using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models.EstadoTicket

{
    public class TipoEstado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string fecha_eliminacion { get; set; }
        public List<Etiqueta> Etiqueta { get; set; }
        public bool Permiso { get; set; }
        public TipoEstado()
        {
            Id = Guid.Empty;
            Nombre = null;
            Descripcion = null;
            Etiqueta = null;
            fecha_eliminacion = null;
    }
    }
}