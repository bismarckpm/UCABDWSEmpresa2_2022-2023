
using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models.DTO.TipoEstado
{
    public class TipoEstadoCreateDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<Guid> etiqueta { get; set; }
    }
}
