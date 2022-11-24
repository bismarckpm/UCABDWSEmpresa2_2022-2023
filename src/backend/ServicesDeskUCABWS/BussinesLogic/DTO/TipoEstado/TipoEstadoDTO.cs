using ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado
{
    public class TipoEstadoDTO
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<EtiquetaDTO> etiqueta { get; set; }
        public Boolean permiso { get; set; }
    }
}
