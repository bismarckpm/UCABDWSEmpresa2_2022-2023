using ModuloPlantillasNotificaciones.Models.PlantillaNotificaciones;
using ModuloPlantillasNotificaciones.Models.EstadoTicket;
using System.Collections.Generic;

namespace ModuloPlantillasNotificaciones.ViewModel.PlantillaNotificaciones
{
    public class PlantillaNuevaViewModel
    {
        public List<TipoEstado> TipoEstados { get; set; }
        public PlantillaNotificacionNueva Plantilla { get; set; }
        public string Message { get; set; }
    }
}