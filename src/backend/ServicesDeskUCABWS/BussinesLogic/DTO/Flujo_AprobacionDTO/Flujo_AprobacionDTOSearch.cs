

using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO
{
    public class Flujo_AprobacionDTOSearch
    {
        public int OrdenAprobacion { get; set; }

        public TipoCargoDTO Tipo_Cargo { get; set; }
    }
}
