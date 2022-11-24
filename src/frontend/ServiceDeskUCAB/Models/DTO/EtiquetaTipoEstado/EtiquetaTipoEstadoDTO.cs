using ServiceDeskUCAB.Models.DTO.TipoEstado;
using System;

namespace ServiceDeskUCAB.Models.DTO.EtiquetaTipoEstado
{
    public class EtiquetaTipoEstadoDTO
    {
        public Guid etiquetaID { get; set; }

        public Guid tipoEstadoID { get; set; }

        //public EtiquetaDTO etiqueta { get; set; }

        public TipoEstadoDTO tipoEstado { get; set; }
    }
}
