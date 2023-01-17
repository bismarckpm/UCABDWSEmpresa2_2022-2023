using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models.ModelsVotos
{
    public class Prioridad
    {
        public Guid id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; }
        public DateTime fecha_descripcion { get; set; }
        public DateTime fecha_ultima_edic { get; set; }
        public string estado { get; set; }

    }
}
