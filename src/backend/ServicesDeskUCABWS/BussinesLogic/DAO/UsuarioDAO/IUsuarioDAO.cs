using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO
{
    public interface IUsuarioDAO
    {
        public List<Usuario> ObtenerUsuarios();
        public Administrador AgregarAdminstrador(Usuario usuario);
        public Cliente AgregarCliente(Usuario usuario);
        public UsuarioDto eliminarUsuario(Guid id);
        public Empleado AgregarEmpleado(Usuario usuario);
        public UserDto_Update ActualizarUsuario(Usuario usuario);
        public UserPasswordDto ActualizarUsuarioPassword(Usuario usuario);
        public void RecuperarClave(string Email);
    }
}
