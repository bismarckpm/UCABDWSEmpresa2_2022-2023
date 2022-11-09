using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCAB.Models
{
    public class Prioridad
    {
        [Key,Required]
        public int PrioridadID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Estado { get; set; }
        public DateTime FechaDescripcion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
    }
   
}

