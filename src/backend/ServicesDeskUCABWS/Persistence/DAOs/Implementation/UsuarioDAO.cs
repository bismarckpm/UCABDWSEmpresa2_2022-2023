using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers;
using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Dto;
using ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Mapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.DAOs.Interface;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.Persistence.DAOs.Implementation
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly DataContext _dataContext;  
        private readonly IMapper _mapper;

        public UsuarioDAO(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Administrador AgregarAdminstrador(Usuario usuario)
        {
            try
            {

                _dataContext.Usuarios.Add(usuario);
                var UsuarioClient = new RolUsuario
                {
                    UserId = usuario.Id,
                    RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298162")
                };
                _dataContext.RolUsuarios.Add(UsuarioClient);
                _dataContext.SaveChanges();

                var nuevoUsuario = _dataContext.Usuarios.Where(User => User.Id == usuario.Id)
                                        .Select(UserDto => new Administrador
                                        {
                                            Id = UserDto.Id,
                                            cedula = UserDto.cedula,
                                            primer_nombre = UserDto.primer_nombre,
                                            primer_apellido = UserDto.primer_apellido,
                                            segundo_nombre = UserDto.segundo_nombre,
                                            segundo_apellido = UserDto.segundo_apellido,
                                            fecha_nacimiento = UserDto.fecha_nacimiento,
                                            gender = UserDto.gender,
                                            correo = UserDto.correo,
                                            password = UserDto.password,
                                            fecha_creacion = UserDto.fecha_creacion,
                                        });

                return nuevoUsuario.First();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }

        }

        public Cliente AgregarCliente(Usuario usuario)
        {
            try
            {

                _dataContext.Usuarios.Add(usuario);
                var UsuarioClient = new RolUsuario
                {
                    UserId = usuario.Id,
                    RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298161")
                };
                _dataContext.RolUsuarios.Add(UsuarioClient);
                _dataContext.SaveChanges();

                var nuevoUsuario = _dataContext.Usuarios.Where(User => User.Id == usuario.Id)
                                        .Select(UserDto => new Cliente
                                        {
                                            Id = UserDto.Id,
                                            cedula = UserDto.cedula,
                                            primer_nombre = UserDto.primer_nombre,
                                            primer_apellido = UserDto.primer_apellido,
                                            segundo_nombre = UserDto.segundo_nombre,
                                            segundo_apellido = UserDto.segundo_apellido,
                                            fecha_nacimiento = UserDto.fecha_nacimiento,
                                            gender = UserDto.gender,
                                            correo = UserDto.correo,
                                            password = UserDto.password,
                                            fecha_creacion = UserDto.fecha_creacion,
                                        });

                return nuevoUsuario.First();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }

        }

        public Empleado AgregarEmpleado(Usuario usuario)
        {
            try
            {

                _dataContext.Usuarios.Add(usuario);
                var UsuarioClient = new RolUsuario
                {
                    UserId = usuario.Id,
                    RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298163")
                };
                _dataContext.RolUsuarios.Add(UsuarioClient);
                _dataContext.SaveChanges();

                var nuevoUsuario = _dataContext.Usuarios.Where(User => User.Id == usuario.Id)
                                        .Select(UserDto => new Empleado
                                        {
                                            Id = UserDto.Id,
                                            cedula = UserDto.cedula,
                                            primer_nombre = UserDto.primer_nombre,
                                            primer_apellido = UserDto.primer_apellido,
                                            segundo_nombre = UserDto.segundo_nombre,
                                            segundo_apellido = UserDto.segundo_apellido,
                                            fecha_nacimiento = UserDto.fecha_nacimiento,
                                            gender = UserDto.gender,
                                            correo = UserDto.correo,
                                            password = UserDto.password,
                                            fecha_creacion = UserDto.fecha_creacion,
                                        });

                return nuevoUsuario.First();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }

        }

        public UsuarioDto eliminarUsuario(Guid id)
        {
            try
            {
                var usuario = _dataContext.Usuarios
                .Where(d => d.Id == id).First();

                _dataContext.Usuarios.Remove(usuario);
                _dataContext.SaveChanges();

                return UserMapper.MapperEntityToDto(usuario);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al eliminar por id: " + id, ex);
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            try
            {
                _dataContext.Usuarios.Include(r => r.Roles).ToList();

                var lista = _dataContext.Usuarios.Include(r => r.Roles).ToList();
                

                return lista;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        public UserDto_Update ActualizarUsuario(Usuario usuario)
        {
            try
            {


                _dataContext.Usuarios.Update(usuario);
                _dataContext.SaveChanges();

                    var data = _dataContext.Usuarios.Where(d => d.Id == usuario.Id).Select(
                        user => new UserDto_Update
                        {
                            id = user.Id,
                            cedula = user.cedula,
                            segundo_nombre = user.segundo_nombre,
                            segundo_apellido = user.segundo_apellido,
                            primer_nombre = user.primer_nombre,
                            primer_apellido = user.primer_apellido,
                            fecha_nacimiento = user.fecha_nacimiento,
                        }

                    );
                    return data.First();
  
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + usuario.Id, ex);
            }
        }

        public UserPasswordDto ActualizarUsuarioPassword(Usuario usuario)
        {
            try
            {


                _dataContext.Usuarios.Update(usuario);
                _dataContext.SaveChanges();

                var data = _dataContext.Usuarios.Where(d => d.Id == usuario.Id).Select(
                    user => new UserPasswordDto
                    {
                        id = user.Id,
                        password = user.password,
                    }

                );
                return data.First();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + usuario.Id, ex);
            }
        }
    }
}
