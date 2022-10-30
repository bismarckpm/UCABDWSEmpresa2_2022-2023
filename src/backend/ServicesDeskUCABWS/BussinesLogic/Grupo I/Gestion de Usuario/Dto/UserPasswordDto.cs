using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Dto
{
    public class UserPasswordDto
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string password { get; set; } = string.Empty;
    }
}
