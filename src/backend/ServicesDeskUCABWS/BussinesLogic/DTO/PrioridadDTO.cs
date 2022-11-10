using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO
{
    public class PrioridadDTO
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaDescripcion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
    }
}
