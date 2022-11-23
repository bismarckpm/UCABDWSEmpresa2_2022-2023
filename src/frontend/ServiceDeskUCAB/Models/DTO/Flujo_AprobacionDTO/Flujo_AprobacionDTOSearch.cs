using ServiceDeskUCAB.Models.DTO.Tipo_CargoDTO;

namespace ServiceDeskUCAB.Models.DTO.Flujo_AprobacionDTO
{
    public class Flujo_AprobacionDTOSearch
    {
        public string IdCargo { get; set; }
        public int? OrdenAprobacion { get; set; }

        public int? Minimo_aprobado_nivel { get; set; }

        public int? Maximo_Rechazado_nivel { get; set; }

        public TipoCargoDTO Tipo_Cargo { get; set; }
    }
}
