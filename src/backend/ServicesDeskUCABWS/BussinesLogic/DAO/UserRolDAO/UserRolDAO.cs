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

namespace ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO
{
    public class UserRolDAO : IUserRol
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UserRolDAO(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public RolUsuarioDTO AgregarRol(RolUsuario rolUsuario)
        {
            try
            {

                _dataContext.RolUsuarios.Add(rolUsuario);
                _dataContext.SaveChanges();

                var nuevoRolUsuario = _dataContext.RolUsuarios.Where(rolu => rolu.UserId == rolUsuario.UserId && rolu.RolId == rolUsuario.RolId)
                                        .Select(d => new RolUsuarioDTO
                                        {
                                            IdUsuario = d.UserId,
                                            IdRol = d.RolId,
                                        });

                return nuevoRolUsuario.First();
            }

            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("Se esta intentando asociar a un rol que no existe", ex);
            }
            catch (SqlException ex) 
            {
                throw new ExceptionsControl("Se esta intentando asociar el mismo rol mas de una vez", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el tipo estado", ex);
            }


        }
        public RolUsuarioDTO EliminarRol(Guid user, Guid Rol)
        {
            try
            {
                var rolusuario = _dataContext.RolUsuarios
                .Where(u => u.UserId == user && u.RolId == Rol).First();

                _dataContext.RolUsuarios.Remove(rolusuario);
                _dataContext.SaveChanges();

                return UserRolMapper.MapperEntityToDtoUR(rolusuario);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Uno de los id (Usuario o rol) es invalido", ex);
            }
        }

        public List<RolUsuarioDTO> ObtenerUsuariosRoles()
        {
            try
            {

                var lista = _dataContext.RolUsuarios.Select(
                    roluser => new RolUsuarioDTO
                    {
                        IdRol = roluser.RolId,
                        IdUsuario = roluser.UserId,
                    });


                return lista.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }
    }
}
