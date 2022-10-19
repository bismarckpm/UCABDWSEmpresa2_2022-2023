using System;

namespace ServicesDeskUCABWS.Models
{
    public class Prioridad
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_descripcion { get; set; }
        public DateTime fecha_ultima_edic { get; set; }
    }
}
