using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO
{
    public class EstadoDTOSearch
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public string? fecha_eliminacion { get; set; }
    }
}
