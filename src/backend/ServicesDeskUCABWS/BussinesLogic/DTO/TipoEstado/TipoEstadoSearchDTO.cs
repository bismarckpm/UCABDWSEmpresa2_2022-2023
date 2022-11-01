using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado
{
    public class TipoEstadoSearchDTO
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<EtiquetaTipoEstado> etiquetaTipoEstado { get; set; }
    }
}
