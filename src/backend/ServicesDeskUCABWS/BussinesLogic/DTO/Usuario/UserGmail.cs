
using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Usuario
{
    public class UserGmail
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string correo { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; } = string.Empty;
    }
}
