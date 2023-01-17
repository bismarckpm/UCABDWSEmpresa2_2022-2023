using ServiceDeskUCAB.Models.DTO.TipoEstado;
using System;

namespace ServiceDeskUCAB.Models.DTO.Plantilla
{
    public class PlantillaNotificacionDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoEstadoDTO TipoEstado { get; set; }
    }
}
