using ServicesDeskUCABWS.Models.DTO.EtiquetasDTO;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models.DTO.TipoEstadoDTO
{
    public class TipoEstadoCreateDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<EtiquetaDTO> Etiqueta { get; set; }
    }
}
