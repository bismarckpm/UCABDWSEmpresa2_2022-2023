using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using System.Collections.Generic;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado
{
    public class TipoEstadoUpdateDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<Guid> etiqueta { get; set; }
    }
}
