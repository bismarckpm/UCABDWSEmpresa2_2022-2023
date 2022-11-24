using ServiceDeskUCAB.Models.DTO.Flujo_AprobacionDTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServiceDeskUCAB.Models.DTO.Tipo_TicketDTO
{
    public class Tipo_TicketDTOCreate
    {

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public string tipo { get; set; }
        public List<FlujoAprobacionDTOCreate> Flujo_Aprobacion { get; set; }
        public List<string> Departamento { get; set; }
        public int? Minimo_Aprobado { get; set; }
        public int? Maximo_Rechazado { get; set; }
    }

}
