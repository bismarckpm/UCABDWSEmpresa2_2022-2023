using System;
using System.Collections.Generic;

namespace ProyectD.Models
{
    public class Tipo_Cargo
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string nivel_jerarquia { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ult_edic { get; set; }
        public DateTime fecha_eliminacion { get; set; }
        public HashSet<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
    }
}
