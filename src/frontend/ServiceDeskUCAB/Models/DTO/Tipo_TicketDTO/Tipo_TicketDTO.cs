
using System.Collections.Generic;
using System;
using ServiceDeskUCAB.Models.DTO.Flujo_AprobacionDTO;

namespace ServiceDeskUCAB.Models.DTO.Tipo_TicketDTO
{
    public class Tipo_TicketDTO
    {

        public string Id { get; set; }

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_elim { get; set; }
        public string tipo { get; set; }
        public List<FlujoAprobacionDTOCreate> Flujo_Aprobacion { get; set; }
        public List<string> Departamento { get; set; }
        public int? Minimo_Aprobado { get; set; }
        public int? Maximo_Rechazado { get; set; }
    }
}
