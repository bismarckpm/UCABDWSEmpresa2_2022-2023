using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Response;
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
        //public UserPasswordDto ActualizarUsuarioPassword(Usuario usuario);
        public string RecuperarClave(string Email);
        //public string ValidarCorreo(string Email);
        public Usuario consularUsuarioID (Guid id);
        public UsuarioDTOAsignarCargo AsignarCargo(UsuarioDTOAsignarCargo userDTO);
    }
}
