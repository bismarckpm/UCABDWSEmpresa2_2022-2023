using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO
{
    public class FlujoAprobacionDTOCreate
    {
        // public string IdTipoTicket { get; set; }
        public string IdCargo { get; set; }
        public int? OrdenAprobacion { get; set; }
        public int? Minimo_aprobado_nivel { get; set; }
        public int? Maximo_Rechazado_nivel { get; set; }

    }
}
