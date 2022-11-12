using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.Dtos
{
    public class PrioridadesDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaDescripcion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
    }
}

