using System.Collections.Generic;
using ServiceDeskUCAB.Models.PlantillaNotificaciones;
using ServiceDeskUCAB.Models.EstadoTicket;

namespace ServiceDeskUCAB.ViewModel.PlantillaNotificaciones
{
    public class PlantillaEditarViewModel
    {
        public List<TipoEstado> TipoEstados { get; set; }
        public PlantillaNotificacion Plantilla { get; set; }
        public string Message { get; set; }
    }
}
