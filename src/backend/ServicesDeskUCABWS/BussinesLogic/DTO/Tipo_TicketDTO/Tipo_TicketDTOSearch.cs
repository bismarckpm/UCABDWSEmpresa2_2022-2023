using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO
{
    public class Tipo_TicketDTOSearch
    {
        public Guid Id { get; set; }

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public String tipo { get; set; }

        public int? Minimo_Aprobado { get; set; }

        public HashSet<Flujo_AprobacionDTOSearch> Flujo_Aprobacion { get; set; }
        public HashSet<DepartamentoSearchDTO> Departamento { get; set; }
    }
}
