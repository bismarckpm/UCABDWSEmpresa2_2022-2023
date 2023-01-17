using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models.TipoTicketsModels
{
    public abstract class Usuario
    {
        public Guid Id { get; set; }

        public int cedula { get; set; }
        public string primer_nombre { get; set; } = string.Empty;

        public string segundo_nombre { get; set; } = string.Empty;
        public string primer_apellido { get; set; } = string.Empty;
        public string segundo_apellido { get; set; } = string.Empty;
        public string fecha_nacimiento { get; set; }
        public char gender { get; set; }
        public string correo { get; set; } = string.Empty;

    }
}
