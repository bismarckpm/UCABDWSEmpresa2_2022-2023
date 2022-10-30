using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Dto;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Persistence.DAOs.Interface
{
    public interface IUserRol
    {
        List<RolUsuarioDTO> ObtenerUsuariosRoles();
        RolUsuarioDTO AgregarRol(RolUsuario rolUsuario);
        RolUsuarioDTO EliminarRol(Guid usuario, Guid rol);
    }
}
