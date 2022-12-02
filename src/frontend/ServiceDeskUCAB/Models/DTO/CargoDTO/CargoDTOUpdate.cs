using System.ComponentModel.DataAnnotations;
using System;

namespace ServiceDeskUCAB.Models.DTO.CargoDTO
{
    public class CargoDTOUpdate
    {
        
        public Guid Id { get; set; }
        public string nombre_departamental { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;

        public string? fecha_eliminacion { get; set; } 
    }
}
