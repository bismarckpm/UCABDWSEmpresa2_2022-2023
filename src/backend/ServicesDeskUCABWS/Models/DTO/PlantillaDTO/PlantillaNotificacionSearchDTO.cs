using System;

namespace ServicesDeskUCABWS.Models.DTO.PlantillaDTO
{
    public class PlantillaNotificacionSearchDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Tipo_Estado TipoEstado { get; set; }
    }
}
