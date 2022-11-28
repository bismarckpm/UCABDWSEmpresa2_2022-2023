using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServicesDeskUCAB.Models;

namespace ServiceDeskUCAB.Models
{
    public class Tipo_Estado
    {
        public int TipoEstadoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Plantilla_NotificacionID { get; set; }

        public List<Etiqueta> Etiqueta { get; set; }
        public List<Estado> ListaEstadosDerivados { get; set; }

        public Plantilla_Notificacion Plantilla_Notificacion { get; set; }
    }
}

