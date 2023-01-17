using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO
{
    public class Tipo_TicketDTOUpdate
    {

        public string Id { get; set; }

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public string tipo { get; set; }
        public List<FlujoAprobacionDTOCreate> Flujo_Aprobacion { get; set; }
        public List<string> Departamento { get; set; }
        public int? Minimo_Aprobado { get; set; }
        public int? Maximo_Rechazado { get; set; }
    }
}
