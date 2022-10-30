using AutoMapper;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Mapper
{
    public class UserMapper : Profile
    {
        public static Administrador MapperEntityToDto(UsuarioDto user)
        {
            return new Administrador
            {
                Id = Guid.NewGuid(),
                cedula = user.cedula,
                primer_nombre = user.primer_nombre,
                segundo_nombre = user.segundo_nombre,   
                primer_apellido = user.primer_apellido,
                segundo_apellido = user.segundo_apellido,
                correo = user.correo,   
                password = user.password,
                fecha_creacion = user.fecha_creacion,
                gender = user.gender,   

            };
            
        }

        public static UsuarioDto MapperEntityToDto(Usuario user)
        {
            return new UsuarioDto
            {
                Id = Guid.NewGuid(),
                cedula = user.cedula,
                primer_nombre = user.primer_nombre,
                segundo_nombre = user.segundo_nombre,
                primer_apellido = user.primer_apellido,
                segundo_apellido = user.segundo_apellido,
                correo = user.correo,
                password = user.password,
                fecha_creacion = user.fecha_creacion,
                gender = user.gender,

            };

        }
    }
}
