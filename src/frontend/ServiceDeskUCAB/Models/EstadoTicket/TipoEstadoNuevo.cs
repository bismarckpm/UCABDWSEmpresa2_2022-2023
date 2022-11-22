using System;
using System.Collections.Generic;

namespace ModuloPlantillasNotificaciones.Models.EstadoTicket
{
    public class TipoEstadoNuevo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<String> Etiqueta { get; set; }
    }
}
