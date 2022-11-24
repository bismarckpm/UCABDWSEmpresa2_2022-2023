using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models.EstadoTicket
{
    public class TipoEstadoNuevo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<String> Etiqueta { get; set; }
        public bool Permiso { get; set; }
    }
}
