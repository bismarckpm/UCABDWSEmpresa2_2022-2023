using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCAB.Models
{
    public class TipoEstado
    {
        public int TipoEstadoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? PlantillaNotificacionID { get; set; }

        public List<Etiqueta> Etiqueta { get; set; }
        public List<Estado> ListaEstadosDerivados { get; set; }

        public PlantillaNotificacion PlantillaNotificacion { get; set; }
    }
}

