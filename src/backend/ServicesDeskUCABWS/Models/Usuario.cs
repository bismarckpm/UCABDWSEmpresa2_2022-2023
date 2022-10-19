using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public int cedula { get; set; }
        public string primer_nombre { get; set; } = string.Empty;
        public string segundo_nombre { get; set; } = string.Empty;
        public string primer_apellido { get; set; } = string.Empty;
        public string segundo_apellido { get; set; } = string.Empty;
        public DateTime fecha_nacimiento { get; set; }
        public char genero { get; set; }
        public string correo { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string rol { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ultima_edicion { get; set; }
        public DateTime fecha_eliminacion { get; set; }
        public HashSet<Votos_Ticket> Votos_Ticket { get; set; }
    }
}
