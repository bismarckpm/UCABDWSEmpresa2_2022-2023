using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Models
{
    public class Usuario
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        private int cedula { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        private string primer_nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        private string segundo_nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        private string primer_apellido { get; set; } = string.Empty;
        [MaxLength(50)]
        [MinLength(3)]
        private string segundo_apellido { get; set; } = string.Empty;
        [Required]
        private DateTime fecha_nacimiento { get; set; }
        [Required]
        private char genero { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        private string correo { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        private string password { get; set; } = string.Empty;
        [Required]
        private DateTime fecha_creacion { get; set; }
        [Required]
        private DateTime fecha_ultima_edicion { get; set; }
        private DateTime fecha_eliminacion { get; set; }
       
    }
}
