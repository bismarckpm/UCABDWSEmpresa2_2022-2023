using ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado
{
    public class TipoEstadoCreateDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<Guid> etiqueta { get; set; }
        public Boolean permiso { get; set; }
    }
}
