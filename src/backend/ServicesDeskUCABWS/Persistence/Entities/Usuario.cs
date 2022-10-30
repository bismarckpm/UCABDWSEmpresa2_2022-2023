using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.Persistence.Entities
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        public int cedula { get; set; }

        [MaxLength(50)]
        [MinLength(3)]
        public string primer_nombre { get; set; } = string.Empty;

        [MaxLength(50)]
        [MinLength(3)]
        public string segundo_nombre { get; set; } = string.Empty;

        [MaxLength(50)]
        [MinLength(3)]
        public string primer_apellido { get; set; } = string.Empty;
        [MaxLength(50)]
        [MinLength(3)]
        public string segundo_apellido { get; set; } = string.Empty;

        public DateTime fecha_nacimiento { get; set; }

        public char gender { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string correo { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string password { get; set; } = string.Empty;

        public DateTime fecha_creacion { get; set; }

        public DateTime fecha_ultima_edicion { get; set; }
        public DateTime fecha_eliminacion { get; set; }
        public ICollection<RolUsuario> Roles { get; set; }
    }
}
