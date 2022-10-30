using System;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Dto
{
    public class UserPasswordDto
    {
        public Guid id { get; set; }
        public string password { get; set; } = string.Empty;
    }
}
