using System.Collections.Generic;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket
{
    public class Tipo_TicketDTO
    {
        public Guid Id { get; set; }

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public String tipo { get; set; }

        public int? Minimo_Aprobado { get; set; }

        public HashSet<Flujo_AprobacionDTO> Flujo_Aprobacion { get; set; }
        public HashSet<DepartamentoDTO> Departamento { get; set; }
    }
}
