using System;

namespace ServicesDeskUCAB.Models.DTO.CargoDTO
{
    public class CargoDTOCreate
    {
        public string nombre_departamental { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;

        public Guid idDepartamento { get; set; }
    }
}
