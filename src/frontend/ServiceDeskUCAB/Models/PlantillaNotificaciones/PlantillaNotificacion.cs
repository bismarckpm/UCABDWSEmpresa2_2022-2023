using Newtonsoft.Json;
using ServiceDeskUCAB.Models.EstadoTicket;
using System;

namespace ServiceDeskUCAB.Models.PlantillaNotificaciones
{
    public class PlantillaNotificacion
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoEstado TipoEstado { get; set; }

    }
}
