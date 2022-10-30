using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Dto;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Mapper
{
    public class UserRolMapper
    {
        public static RolUsuario MapperEntityToDtoUR(RolUsuarioDTO user)
        {
            return new RolUsuario
            {
                UserId = user.IdUsuario,
                RolId = user.IdRol,
            };

        }

        public static RolUsuarioDTO MapperEntityToDtoUR(RolUsuario user)
        {
            return new RolUsuarioDTO
            {
                IdUsuario= user.UserId,
                IdRol = user.RolId,
            };

        }

    }
}
