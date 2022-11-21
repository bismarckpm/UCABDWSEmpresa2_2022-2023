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
                UserId = user.idusuario,
                RolId = user.idrol,
            };

        }

        public static RolUsuarioDTO MapperEntityToDtoUR(RolUsuario user)
        {
            return new RolUsuarioDTO
            {
                idusuario = user.UserId,
                idrol = user.RolId,
            };

        }

    }
}
