using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.Models
{
    public class TipoCargo
    {
        public int TipoCargoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NivelJerarquia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public List<FlujoAprobacion> FlujoAprobacion { get; set; }
    }
}

