using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
    public class Tipo
    {
        public string Id { get; set; }

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public string tipo { get; set; }
        public List<FlujoAprobacion> Flujo_Aprobacion { get; set; }
        public List<string> Departamento { get; set; }
        public int? Minimo_Aprobado { get; set; }
        public int? Maximo_Rechazado { get; set; }

    }
    
}
