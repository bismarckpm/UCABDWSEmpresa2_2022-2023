using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Dto;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Persistence.DAOs.Interface
{
    public interface IUsuarioDAO
    {
        public List<Usuario> ObtenerUsuarios();
        public Administrador AgregarAdminstrador(Usuario usuario);
        public Cliente AgregarCliente(Usuario usuario);
        public UsuarioDto eliminarUsuario(Guid id);
        public Empleado AgregarEmpleado (Usuario usuario);
        public UserDto_Update ActualizarUsuario(Usuario usuario);
        public UserPasswordDto ActualizarUsuarioPassword(Usuario usuario);
    }
}
