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
using System.Data;
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

                var nuevoRolUsuario = _dataContext.RolUsuarios.Where(rolu => rolu.userid == rolUsuario.userid && rolu.rolid == rolUsuario.rolid)
                                        .Select(d => new RolUsuarioDTO
                                        {
                                            idusuario = d.userid,
                                            idrol = d.userid,
                                        });

                return nuevoRolUsuario.First();
            }

            catch (Exception ex)
            {
                throw new ExceptionsControl("Uno de los id (Usuario o rol) es invalido", ex);
            }


        }

        public RolUsuarioDTO consularRolID(Guid usuario)
        {
            try
            {
                var data = _dataContext.RolUsuarios.AsNoTracking().Where(p => p.userid == usuario).Single();
                var user = new RolUsuarioDTO { idrol = data.rolid,idusuario = data.userid };
                return user;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese ID", ex);
            }
        }

        public RolUsuarioDTO EliminarRol(Guid user, Guid Rol)
        {
            try
            {
                var rolusuario = _dataContext.RolUsuarios
                .Where(u => u.userid == user && u.rolid == Rol).First();

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
                        idrol = roluser.rolid,
                        idusuario = roluser.userid,
                    });


                return lista.ToList();

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Algo salio mal en la consulta", ex);
            }
        }
    }
}
