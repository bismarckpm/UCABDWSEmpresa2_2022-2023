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
                userid = user.idusuario,
                rolid = user.idrol,
            };

        }

        public static RolUsuarioDTO MapperEntityToDtoUR(RolUsuario user)
        {
            return new RolUsuarioDTO
            {
                idusuario = user.userid,
                idrol = user.rolid,
            };

        }

    }
}
