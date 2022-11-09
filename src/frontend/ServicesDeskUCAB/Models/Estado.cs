using System;

namespace ServicesDeskUCAB.Models
{
    public class Estado
    {
        public int EstadoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoEstadoID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }

        public TipoEstado TipoEstado { get; set; }
    }
}

