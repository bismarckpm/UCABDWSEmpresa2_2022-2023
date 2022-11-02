using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO
{
    public interface IUserRol
    {
        List<RolUsuarioDTO> ObtenerUsuariosRoles();
        RolUsuarioDTO AgregarRol(RolUsuario rolUsuario);
        RolUsuarioDTO EliminarRol(Guid usuario, Guid rol);
    }
}
