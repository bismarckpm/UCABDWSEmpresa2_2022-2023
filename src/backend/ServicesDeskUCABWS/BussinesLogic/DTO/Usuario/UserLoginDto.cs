using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Usuario
{
    public class UserLoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string correo { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string password { get; set;  }
    }
}
