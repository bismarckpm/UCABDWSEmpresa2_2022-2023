﻿using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mappers.MapperGrupo;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO
{
    public class GrupoDAO : IGrupoDAO
    {
        private readonly DataContext _dataContext;

        //Constructor
        public GrupoDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //Agregar Grupo
        public GrupoDto AgregarGrupoDao(Grupo grupo)
        {
            try
            {
                _dataContext.Grupos.Add(grupo);
                _dataContext.SaveChanges();

                var nuevoGrupo = _dataContext.Grupos.Where(d => d.Id == grupo.Id)
                                        .Select(d => new GrupoDto
                                        {
                                            Id = d.Id,
                                            descripcion = d.descripcion,
                                            nombre = d.nombre,
                                            fecha_creacion = d.fecha_creacion
                                        });
                return nuevoGrupo.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        //Consultar Grupo
        public List<GrupoDto> ConsultarGruposDao()
        {
            try
            {
                var lista = _dataContext.Grupos.Select(
                    d => new GrupoDto
                    {
                        Id = d.Id,
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
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        //Consultar por ID 
        public GrupoDto ConsultarPorIdDao(Guid idGrupo)
        {
            var grupo = _dataContext.Grupos
                        .Where(d => d.Id == idGrupo).First();

            return GrupoMapper.MapperEntityToDtoDefault(grupo);
        }

        //Eliminar Grupo
        public GrupoDto EliminarGrupoDao(Guid idGrupo)
        {
            try
            {
                var grupo = _dataContext.Grupos
                .Where(d => d.Id == idGrupo).First();

                _dataContext.Grupos.Remove(grupo);
                _dataContext.SaveChanges();

                return GrupoMapper.MapperEntityToDto(grupo);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al eliminar por id: " + idGrupo, ex);
            }
        }

        //Modificar Grupo
        public GrupoDto_Update ModificarGrupoDao(Grupo grupo)
        {
            try
            {
                _dataContext.Grupos.Update(grupo);
                _dataContext.SaveChanges();

                var data = _dataContext.Grupos.Where(d => d.Id == grupo.Id).Select(
                    d => new GrupoDto_Update
                    {
                        Id = d.Id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_creacion = d.fecha_creacion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion
                    }

                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + grupo.Id, ex);
            }
        }
    }
}
