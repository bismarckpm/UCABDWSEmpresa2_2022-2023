using System;

namespace ServiceDeskUCAB.Models.DTO.Plantilla

{
    public class PlantillaNotificacionDTOCreate
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
    }
}
