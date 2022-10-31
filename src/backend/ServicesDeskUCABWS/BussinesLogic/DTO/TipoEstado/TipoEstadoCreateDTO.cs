using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado
{
    public class TipoEstadoCreateDTO
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        //public HashSet<EtiquetaDTO> Etiqueta { get; set; }
    }
}
