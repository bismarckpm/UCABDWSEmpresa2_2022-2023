using System.Collections.Generic;
using ServiceDeskUCAB.Models.PlantillaNotificaciones;
using ServiceDeskUCAB.Models.EstadoTicket;

namespace ServiceDeskUCAB.ViewModel.PlantillaNotificaciones
{
    public class PlantillaNuevaViewModel
    {
        public List<TipoEstado> TipoEstados { get; set; }
        public PlantillaNotificacionNueva Plantilla { get; set; }
        public string Message { get; set; }
    }
}