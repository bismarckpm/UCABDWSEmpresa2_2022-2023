using System;

namespace ServicesDeskUCABWS.Entities
{
    public class DepartamentoTipo_Ticket
    {
        
        public Guid Tipo_Ticekt_Id { get; set; }

        public Guid DepartamentoId { get; set; }

        public Tipo_Ticket tipo_Ticket { get; set; }

        public Departamento departamento { get; set; }
        
    }
}
