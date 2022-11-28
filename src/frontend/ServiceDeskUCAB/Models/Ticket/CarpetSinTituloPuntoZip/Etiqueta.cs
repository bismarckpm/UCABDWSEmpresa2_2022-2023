using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
    public class Etiqueta
    {
        public int EtiquetaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Tipo_Estado> TipoEstados { get; set; }
    }
}

