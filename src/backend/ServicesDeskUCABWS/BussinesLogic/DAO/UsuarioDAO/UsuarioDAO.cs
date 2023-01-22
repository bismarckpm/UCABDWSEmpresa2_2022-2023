using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
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
        private readonly IMapper _mapper;

        public UsuarioDAO(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;   
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

        public Empleado consularEmpleadoID(Guid id)
        {
            try
            {
                var data = _dataContext.Empleados.AsNoTracking().Where(p => p.Id == id && p.fecha_eliminacion == default(DateTime)).Single();
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

        public List<UsuarioGeneralDTO> ObtenerEmpleados()
        {
            try
            {
                var listaGeneral = new List<UsuarioGeneralDTO>();
                var listaEmpleados = _dataContext.Empleados.Include(x=>x.Cargo).Include(r => r.Roles).ThenInclude(x=>x.Rol).Where(x => x.fecha_eliminacion == default(DateTime)).ToList();
                listaGeneral.AddRange(_mapper.Map<List<UsuarioGeneralDTO>>(listaEmpleados));
                var listaAdministrador = _dataContext.Administradores.Include(r => r.Roles).ThenInclude(x => x.Rol).Where(x => x.fecha_eliminacion == default(DateTime)).ToList();
                listaGeneral.AddRange(_mapper.Map<List<UsuarioGeneralDTO>>(listaAdministrador));
                return listaGeneral;

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema en la consulta de los empleados", ex);
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
                throw new ExceptionsControl("Uno de los campos esta vacio o el correo ya existe", ex);
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

        public UsuarioDTOAsignarCargo AsignarCargo(UsuarioDTOAsignarCargo userDTO)
        {
            try
            {
                var cargo = _dataContext.Cargos.Find(userDTO.idCargo);
                if (cargo == null)
                {
                    throw new ExceptionsControl("No se encontro el cargo ingresado");
                }
                var usuario = _dataContext.Empleados.Find(userDTO.idUsuario);
                if (usuario == null)
                {
                    throw new ExceptionsControl("No se encontro el usuario ingresado");
                }

                usuario.Cargo = cargo;

                EliminarVotosPendientes(usuario);
                AgregarVotosCargo(usuario);

                _dataContext.Empleados.Update(usuario);
                _dataContext.DbContext.SaveChanges();

                return new UsuarioDTOAsignarCargo()
                {
                    idCargo = usuario.Cargo.id,
                    idUsuario = usuario.Id
                };

            }
            catch (ExceptionsControl ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw new ExceptionsControl("Formato no valido", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo actualizar el cargo por error desconocido.",ex);
            }
        }

        public string RevocarCargo(Guid idusuario)
        {
            try
            {
                var usuario = _dataContext.Empleados.Include(x=>x.Cargo).Where(x=>x.Id == idusuario).FirstOrDefault();
                if (usuario == null)
                {
                    throw new ExceptionsControl("No se encontro el usuario ingresado");
                }

                usuario.Cargo = null;

                EliminarVotosPendientes(usuario);

                _dataContext.Empleados.Update(usuario);
                _dataContext.DbContext.SaveChanges();

                return usuario.Id.ToString();

            }
            catch (ExceptionsControl ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw new ExceptionsControl("Formato no valido", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo actualizar el cargo por error desconocido.", ex);
            }
        }

        public void AgregarVotosCargo(Empleado usuario)
        {
            var TicketsPendiente = _dataContext.Tickets
                .Include(x => x.Estado)
                .ThenInclude(x => x.Estado_Padre)
                .Include(x=> x.Tipo_Ticket)
                .ThenInclude(x=>x.Flujo_Aprobacion)
                .Where(x=>x.Estado.Estado_Padre.nombre == "Pendiente").ToList();
            
            TicketsPendiente = TicketsPendiente
            .Where(ticket => ticket.Tipo_Ticket.Flujo_Aprobacion.Where(flujo=> flujo.OrdenAprobacion == null || flujo.OrdenAprobacion==ticket.nro_cargo_actual)
                        .Select(x => x.IdCargo).Contains( usuario.Cargo.id ))
            .ToList();

            

            var ListaVotos = TicketsPendiente.Select(x => new Votos_Ticket()
            {
                IdTicket = x.Id,
                IdUsuario = usuario.Id,
                Ticket = x,
                Empleado = usuario,
                voto = "Pendiente",
                Turno = x.nro_cargo_actual
            });
            _dataContext.Votos_Tickets.AddRange(ListaVotos);

        }

        private void EliminarVotosPendientes(Empleado usuario)
        {
            var Votos = _dataContext.Votos_Tickets.Where(x => x.IdUsuario == usuario.Id);
            _dataContext.Votos_Tickets.RemoveRange(Votos);
        }
    }
}

