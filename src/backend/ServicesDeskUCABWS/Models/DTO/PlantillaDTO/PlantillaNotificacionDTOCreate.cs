using System;

namespace ServicesDeskUCABWS.Models.DTO.PlantillaDTO
{
    public class PlantillaNotificacionDTOCreate
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
    }
}
