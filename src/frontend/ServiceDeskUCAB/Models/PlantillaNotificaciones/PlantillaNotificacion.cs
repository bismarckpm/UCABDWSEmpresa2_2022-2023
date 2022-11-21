using ModuloPlantillasNotificaciones.Models.EstadoTicket;
using Newtonsoft.Json;
using System;

namespace ModuloPlantillasNotificaciones.Models.PlantillaNotificaciones
{
    public class PlantillaNotificacion
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoEstado TipoEstado { get; set; }

    }
}
