using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Entities
{
    public class EtiquetaTipoEstado
    {
        public Guid etiquetaID { get; set; }

        public Guid tipoEstadoID { get; set; }

        public Etiqueta etiqueta { get; set; }
       
        public Tipo_Estado tipoEstado { get; set; }
    }
}
