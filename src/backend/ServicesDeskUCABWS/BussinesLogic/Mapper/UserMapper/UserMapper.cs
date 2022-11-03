using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;

using ServicesDeskUCABWS.Entities;

using System;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper
{
    public class UserMapper : Profile
    {
        public static Administrador MapperEntityToDtoAdmin(UsuarioDto user)
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
                fecha_creacion = DateTime.Now.Date,
                gender = user.gender,
                fecha_nacimiento = user.fecha_nacimiento,

            };

        }

        public static Cliente MapperEntityToDtoClient(UsuarioDto user)
        {
            return new Cliente
            {
                Id = Guid.NewGuid(),
                cedula = user.cedula,
                primer_nombre = user.primer_nombre,
                segundo_nombre = user.segundo_nombre,
                primer_apellido = user.primer_apellido,
                segundo_apellido = user.segundo_apellido,
                correo = user.correo,
                password = user.password,
                fecha_creacion = DateTime.Now.Date,
                gender = user.gender,
                fecha_nacimiento = user.fecha_nacimiento,

            };

        }

        public static Empleado MapperEntityToDtoEmp(UsuarioDto user)
        {
            return new Empleado
            {
                Id = Guid.NewGuid(),
                cedula = user.cedula,
                primer_nombre = user.primer_nombre,
                segundo_nombre = user.segundo_nombre,
                primer_apellido = user.primer_apellido,
                segundo_apellido = user.segundo_apellido,
                correo = user.correo,
                password = user.password,
                fecha_creacion = DateTime.Now.Date,
                gender = user.gender,
                fecha_nacimiento = user.fecha_nacimiento,

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
                fecha_creacion = DateTime.Now.Date,
                gender = user.gender,
                fecha_nacimiento = user.fecha_nacimiento,

            };

        }

        public static Usuario MapperEntityToDtoUpdate(UserDto_Update user)
        {
            return new Usuario
            {
                Id = user.id,
                primer_apellido = user.primer_apellido,
                primer_nombre = user.primer_nombre,
                segundo_apellido = user.segundo_apellido,
                segundo_nombre = user.segundo_nombre,
                cedula = user.cedula,
                fecha_nacimiento = user.fecha_nacimiento,

            };
        }

        public static Usuario MapperEntityToDtoUpdatePassword(UserPasswordDto user)
        {
            return new Usuario
            {
                Id = user.id,
                password = user.password,
            };
        }
    }
}
