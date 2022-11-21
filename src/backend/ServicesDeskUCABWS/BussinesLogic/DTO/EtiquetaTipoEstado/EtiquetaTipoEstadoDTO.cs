using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado
{
    public class EtiquetaTipoEstadoDTO
    {
        public Guid etiquetaID { get; set; }

        public Guid tipoEstadoID { get; set; }

        //public EtiquetaDTO etiqueta { get; set; }

        public TipoEstadoDTO tipoEstado { get; set; }
    }
}
