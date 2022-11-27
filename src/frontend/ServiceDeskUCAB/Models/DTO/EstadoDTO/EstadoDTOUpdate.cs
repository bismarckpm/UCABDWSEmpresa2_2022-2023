
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServiceDeskUCAB.Models.DTO.EstadoDTO
{
    public class EstadoDTOUpdate
    {
        public Guid Id { get; set; }

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

    }
}
