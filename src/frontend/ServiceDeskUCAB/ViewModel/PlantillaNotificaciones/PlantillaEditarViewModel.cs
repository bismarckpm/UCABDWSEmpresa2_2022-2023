using ModuloPlantillasNotificaciones.Models.PlantillaNotificaciones;
using ModuloPlantillasNotificaciones.Models.EstadoTicket;
using System.Collections.Generic;

namespace ModuloPlantillasNotificaciones.ViewModel.PlantillaNotificaciones
{
    public class PlantillaEditarViewModel
    {
        public List<TipoEstado> TipoEstados { get; set; }
        public PlantillaNotificacion Plantilla { get; set; }
        public string Message { get; set; }
    }
}
