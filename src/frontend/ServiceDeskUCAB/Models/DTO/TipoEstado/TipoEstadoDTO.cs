
using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models.DTO.Etiqueta;

namespace ServiceDeskUCAB.Models.DTO.TipoEstado
{
    public class TipoEstadoDTO
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<EtiquetaDTO> etiqueta { get; set; }
    }
}
