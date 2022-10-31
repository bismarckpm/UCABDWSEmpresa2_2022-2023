using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Usuario
{
    public class UsuarioDto
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int cedula { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string primer_nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string segundo_nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string primer_apellido { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string segundo_apellido { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_nacimiento { get; set; }
        [Required]
        public char gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string correo { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_creacion { get; set; }
        public RolUsuario Roles { get; set; }
    }
}
