using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly IDataContext _dataContext;   

        public UsuarioDAO(IDataContext dataContext)
        {
            _dataContext = dataContext;
          
        }

        public Usuario consularUsuarioID(Guid id)
        {
            try
            {
                var data = _dataContext.Usuarios.AsNoTracking().Where(p => p.Id == id && p.fecha_eliminacion==default(DateTime)).Single();
                return data;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe un usuario con ese ID", ex);
            }
            
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
                _dataContext.DbContext.SaveChanges();

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
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("El correo electronico ya existe", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el cliente", ex);
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
                _dataContext.DbContext.SaveChanges();

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
                                            fecha_creacion = new DateTime(),
                                        });

                return nuevoUsuario.First();
            }
            /*catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("El correo electronico ya existe", ex);
            }*/
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el cliente", ex);
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
                _dataContext.DbContext.SaveChanges();

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

            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("El correo electronico ya existe", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el cliente", ex);
            }

        }

        public UsuarioDto eliminarUsuario(Guid id)
        {
            try
            {
                var usuario = _dataContext.Usuarios.Where(d => d.Id == id).First();

                usuario.fecha_eliminacion = DateTime.Now.Date;
                _dataContext.DbContext.SaveChanges();

                return UserMapper.MapperEntityToDto(usuario);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Fallo al eliminar por id: " + id, ex);
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            try
            {
                _dataContext.Usuarios.Include(r => r.Roles).ToList();

                var lista = _dataContext.Usuarios.Include(r => r.Roles).Where(x=> x.fecha_eliminacion==default(DateTime)).ToList();

                return lista;

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema en la consulta de los usuarios", ex);
            }
        }

        public UserDto_Update ActualizarUsuario(Usuario usuario)
        {
            try
            {
                var Firstusuario = _dataContext.Usuarios.Where(d => d.Id == usuario.Id).Select(user => new Usuario
                {
                    Id = usuario.Id,
                    cedula = usuario.cedula,
                    segundo_nombre = usuario.segundo_nombre,
                    segundo_apellido = usuario.segundo_apellido,
                    primer_nombre = usuario.primer_nombre,
                    primer_apellido = usuario.primer_apellido,
                    fecha_nacimiento = usuario.fecha_nacimiento,
                    gender = usuario.gender,
                    correo = usuario.correo,
                    password = user.password,
                    fecha_creacion = user.fecha_creacion,
                    fecha_ultima_edicion = DateTime.Now,
                });

                _dataContext.Usuarios.Update(Firstusuario.First());
                _dataContext.DbContext.SaveChanges();

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
                        gender = user.gender,
                        correo = user.correo,
                    }

                );
                return data.First();

            }

            catch (Exception ex)
            {
                throw new ExceptionsControl("Uno de los campos esta vacio", ex);
            }
        }

        public UserPasswordDto ActualizarUsuarioPassword(Usuario usuario)
        {
            try
            {
                (from p in _dataContext.Usuarios
                 where p.Id == usuario.Id
                 select p).ToList().ForEach(x => x.password = usuario.password);

                _dataContext.DbContext.SaveChanges();

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
                throw new ExceptionsControl("La id de usuario no existe", ex);
            }
        }
        public string ValidarCorreo(string Email)
        {
            try
            {
                var usuario = _dataContext.Usuarios.Where(u => u.correo == Email && u.fecha_eliminacion != default(DateTime)).FirstOrDefault();
                return "El correo es valido";
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("El correo no esta registrado", ex);
            }
        }

        public string RecuperarClave(string email)
        {
            try
            {
                var usuario = _dataContext.Usuarios.Where(u => u.correo == email && u.fecha_eliminacion == default(DateTime)).FirstOrDefault();
                var fromAddress = new MailAddress("DesarrolloSoftwareUCAB2@hotmail.com", "SERVICE UCABDESK");
                var toAddress = new MailAddress(usuario.correo, "To Name");
                const string fromPassword = "Desarrollo_SoftwareUCAB_2";
                const string subject = "Recuperacion de contraseña";
                string body = "<h3>Tu anterior contraseña es <a>" + usuario.password + "</a></h3>";

                var smtp = new SmtpClient
                {
                    Host = "smtp.office365.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
            })
                {
                    smtp.Send(message);
                }

                return "Correo enviado";
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El correo no esta registrado", ex);
            }


        }
    }
}

