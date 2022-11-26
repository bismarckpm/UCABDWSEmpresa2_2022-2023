using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperGrupo;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperDepartamento;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using System.Text.RegularExpressions;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO
{
    public class GrupoDAO : IGrupoDAO
    {
        private readonly IDataContext _dataContext;

        //Constructor
        public GrupoDAO(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //Agregar Grupo
        public GrupoDto AgregarGrupoDao(Grupo grupo)
        {
            try
            {

                    _dataContext.Grupos.Add(grupo);
                    _dataContext.DbContext.SaveChanges();
                

                var nuevoGrupo = _dataContext.Grupos.Where(d => d.id == grupo.id)
                                        .Select(d => new GrupoDto
                                        {
                                            id = d.id,
                                            descripcion = d.descripcion,
                                            nombre = d.nombre,
                                            fecha_creacion = d.fecha_creacion
                                        });
                return nuevoGrupo.First();
            }
            catch (Exception ex)
            {
				throw new ExceptionsControl("Error al momento de registrar", ex);
			}
        }

        //Retorna la lista de grupos
        public List<GrupoDto> ConsultarGruposDao()
        {
            try
            {
                var lista = _dataContext.Grupos.Select(
                    d => new GrupoDto
                    {
                        id = d.id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion,
                        fecha_eliminacion = d.fecha_eliminacion
                    }
                );
                return lista.ToList();
            }
			catch (Exception ex)
			{
				throw new ExceptionsControl("No hay grupos registrados", ex);
			}
		}

        //Consultar grupo por ID 
        public GrupoDto ConsultarPorIdDao(Guid idGrupo)
        {
            try
            {
                var grupo = _dataContext.Grupos
                            .Where(d => d.id == idGrupo).First();

                return GrupoMapper.MapperEntityToDtoDefault(grupo);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El grupo" + idGrupo + "No esta registrado", ex);
            }
        }

        //Eliminar Grupo
        public GrupoDto EliminarGrupoDao(Guid idGrupo)
        {
            var grupoDto = new GrupoDto(); 

			try
            {
                var grupo = _dataContext.Grupos
                           .Where(d => d.id == idGrupo).First();

                if (grupo != null)
                {
                    grupo.fecha_eliminacion = DateTime.Now.Date;
                    _dataContext.DbContext.SaveChanges();

                    if (QuitarAsociacion(idGrupo))
                    {
						grupoDto = GrupoMapper.MapperEntityToDto(grupo);
                    }
                }
				   return grupoDto;
			}
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el grupo" + " " + idGrupo, ex);
            }
		}

        //Modificar Grupo
        public GrupoDto_Update ModificarGrupoDao(Grupo grupo)
        {
            try
            {

                    _dataContext.Grupos.Update(grupo);
                    _dataContext.DbContext.SaveChanges();


                var data = _dataContext.Grupos.Where(d => d.id == grupo.id).Select(
                    d => new GrupoDto_Update
                    {
                        Id = d.id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion
                    }

                );
                return data.First();
			}
			catch (DbUpdateException ex)
			{
				throw new ExceptionsControl("Fallo al actualizar el grupo: " + grupo.nombre, ex);
			}
			catch (Exception ex)
			{
				throw new ExceptionsControl("Fallo al actualizar un grupo", ex);
			}
		}

        
        public bool QuitarAsociacion(Guid grupoId)
        {
            var listaDept = _dataContext.Departamentos.Where(x => x.id_grupo == grupoId);

            if (listaDept != null)
            {

                foreach (var item in listaDept)
                {
                    item.id_grupo = null;

                }
                _dataContext.DbContext.SaveChanges();
                return true;

            }
            return false;
        }

        //Retorna una lista de grupo que no están eliminados
        public List<GrupoDto> ConsultarGrupoNoEliminado()
        {
            try
            {
                var lista = _dataContext.Grupos.Where(x => x.fecha_eliminacion == null).Select(
                    d => new GrupoDto
                    {
                        id = d.id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion,
                        fecha_eliminacion = d.fecha_eliminacion

                    }
                );

                return lista.ToList();

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No hay grupos eliminados", ex);
            }
        }

        public bool ExisteGrupo(Grupo grupo)
        {
            bool existe = false;

            try
            {
                var nuevoGrupo = _dataContext.Grupos.Where(d => d.nombre.Equals(grupo.nombre));
                if (nuevoGrupo.Count() != 0)
                    existe = true;
            }
			catch (Exception ex)
			{
				throw new ExceptionsControl("No se encuentra el grupo" + " " + grupo.id, ex);
			}
			return existe;
        }
     
    }
}

