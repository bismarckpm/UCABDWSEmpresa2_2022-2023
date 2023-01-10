using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.Modelos_de_Usuario;
using ServiceDeskUCAB.Models.DTO.Usuario;
using ServiceDeskUCAB.Models.Response;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicioUsuario_API
    {
        Task<List<UsuariosRol>> Lista();
        Task<JObject> Guardar(UsuariosRol usuarios);
        Task<JObject> Eliminar(Guid id);
        Task<JObject> GuardarEmpleado(UsuariosRol usuarios);
        Task<JObject> GuardarAdminstrador(UsuariosRol usuarios);
        Task<UsuariosRol> MostrarInfoUsuario(Guid id);
        Task<JObject> EditarUsuario(UpdateUser user);
        Task<Roles> ObtenerRoles(Guid roles);
        Task<JObject> ValidarLogin(Credenciales_Login user);
        Task<JObject> RecuperarContraseña(RecuperarPasswordModel email);
        Task<JObject> EliminarRol(RolUser roles);
        Task<ApplicationResponse<UsuarioDTOAsignarCargo>> AsignarCargo(Guid idUsuario, Guid idCargo);
        Task<ApplicationResponse<string>> RevocarCargo(Guid idUsuario);
        Task<List<DepartamentoCargoDTO>> ListaDepartamento();
    }
}
