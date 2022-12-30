using Microsoft.AspNetCore.Authorization.Infrastructure;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Usuario
{
    public class UsuarioGeneralDTO
    {
        public Guid Id { get; set; }
        public int cedula { get; set; }
        public string primer_nombre { get; set; } = string.Empty;

        public string segundo_nombre { get; set; } = string.Empty;

        public string primer_apellido { get; set; } = string.Empty;

        public string segundo_apellido { get; set; } = string.Empty;

        public string fecha_nacimiento { get; set; }

        public char gender { get; set; }

        public string correo { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

        public CargoDTOUpdate cargo { get; set; }

        public List<RolUsuario> Roles { get; set; }
    }
}
