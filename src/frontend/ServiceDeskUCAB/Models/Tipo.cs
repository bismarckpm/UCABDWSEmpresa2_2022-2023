using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
    public class Tipo
    {
        public Guid Id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string tipo { get; set; }
        public Depa[] Departamento { get; set; }

        public int? Minimo_Aprobado { get; set; }
        
    }
    
}
