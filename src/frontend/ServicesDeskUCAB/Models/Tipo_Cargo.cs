using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.Models
{
    public class Tipo_Cargo
    {
        public int Tipo_CargoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NivelJerarquia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public List<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
    }
}

