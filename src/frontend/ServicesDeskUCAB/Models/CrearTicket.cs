using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.Models
{
	public class CrearTicket
	{
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public Guid empleado_id { get; set; }
        public Guid prioridad_id { get; set; } 
        public Guid tipoTicket_id { get; set; }
        public Guid departamentoDestino_Id { get; set; }
    }
}

