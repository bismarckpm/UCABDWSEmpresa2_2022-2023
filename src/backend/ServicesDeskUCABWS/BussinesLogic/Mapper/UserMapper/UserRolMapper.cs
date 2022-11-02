using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper
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
                IdUsuario = user.UserId,
                IdRol = user.RolId,
            };

        }

    }
}
