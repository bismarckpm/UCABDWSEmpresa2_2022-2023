using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models.DTO.Usuario
{
    public class UserPasswordDto
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
