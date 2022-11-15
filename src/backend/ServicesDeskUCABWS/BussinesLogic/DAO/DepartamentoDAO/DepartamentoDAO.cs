using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mappers.MapperDepartamento;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO
{
    public class DepartamentoDAO : IDepartamentoDAO
    {
        private readonly DataContext _dataContext;

        //Constructor
        public DepartamentoDAO(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //Registrar un Departamento
        public DepartamentoDto AgregarDepartamentoDAO(Departamento departamento)
        {
            try
            {

                if (ExisteDepartamento(departamento) == false)
                {

                    _dataContext.Departamentos.Add(departamento);
                    _dataContext.SaveChanges();
                }

                var nuevoDepartamento = _dataContext.Departamentos.Where(d => d.Id == departamento.Id)
                        .Select(d => new DepartamentoDto
                        {
                            id = d.Id,
                            descripcion = d.descripcion,
                            nombre = d.nombre,
                            fecha_creacion = d.fecha_creacion
                        }).First();

                return nuevoDepartamento;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el departamento" + " " + departamento.nombre, ex);
            }
        }

        //Eliminar un Departamento
        public DepartamentoDto eliminarDepartamento(Guid id)
        {
            try
            {
                var departamento = _dataContext.Departamentos
                           .Where(d => d.Id == id).First();

                if (ExisteDepartamento(departamento) == false)
                {
                    departamento.fecha_eliminacion = DateTime.Now.Date;
                    // departamento. = null;
                    _dataContext.SaveChanges();
                }
                return DepartamentoMapper.MapperEntityToDto(departamento);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el departamento" + " " + id, ex);
            }
        }

        //Actualizar departamentos
        public DepartamentoDto_Update ActualizarDepartamento(Departamento departamento)
        {
            try
            {
                if (ExisteDepartamento(departamento) == false)
                {
                    _dataContext.Departamentos.Update(departamento);
                    _dataContext.SaveChanges();
                }

                var data = _dataContext.Departamentos.Where(d => d.Id == departamento.Id).Select(
                    d => new DepartamentoDto_Update
                    {
                        id = d.Id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion
                    }

                );
                return data.First();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el departamento" + " " + departamento.Id, ex);
            }
        }

        //Consultar Departamento por ID
        public DepartamentoDto ConsultarPorID(Guid id)
        {

            try
            {

                var departamento = _dataContext.Departamentos
               .Where(d => d.Id == id).First();
                return DepartamentoMapper.MapperEntityToDtoDefault(departamento);

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el departamento" + " " + id, ex);
            }
        }


        //Consulta todos los departamentos (Eliminados y disponibles)

        public List<DepartamentoDto> ConsultarDepartamentos()
        {
            try
            {
                var lista = _dataContext.Departamentos.Select(
                    d => new DepartamentoDto
                    {
                        id = d.Id,
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
                throw new ExceptionsControl("No hay departamentos registrados", ex);
            }
        }

        //Retorna una lista de departamentos que no están eliminados
        public List<DepartamentoDto> DeletedDepartamento()
        {
            try
            {
                var lista = _dataContext.Departamentos.Where(x => x.fecha_eliminacion == null).Select(
                    d => new DepartamentoDto
                    {
                        id = d.Id,
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
                throw new ExceptionsControl("No hay departamentos registrados", ex);
            }
        }

        //Listar departamentos por el identificador de un grupo
        public List<DepartamentoDto> GetByIdDepartamento(Guid idGrupo)
        {
            try
            {

                var departamentos = _dataContext.Departamentos.Where(grupo => grupo.Id == idGrupo).Select(
                        d => new DepartamentoDto
                        {
                            id = d.Id,
                            nombre = d.nombre,
                            descripcion = d.descripcion,
                            fecha_creacion = d.fecha_creacion,
                            fecha_ultima_edicion = d.fecha_ultima_edicion,
                            fecha_eliminacion = d.fecha_eliminacion
                        }
                     );
                return departamentos.ToList();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El departamento" + idGrupo + "No esta registrado", ex);
            }
        }

        public Departamento AsignarGrupoToDepartamento(Guid idGrupo, Guid idDept)
        {
            try
            {
                Departamento result = (from dept in _dataContext.Departamentos
                                       where dept.Id == idDept
                                       select dept).SingleOrDefault();

                if (result is not null)
                {
                    result.Id = idGrupo;
                    _dataContext.SaveChanges();
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new ExceptionsControl("Fallo al asignar grupo: " + idGrupo + "al departamento" + idDept, ex);
            }
        }

        private bool ExisteDepartamento(Departamento departamento)
        {
            bool existe = false;

            try
            {
                var nuevoDepartamento = _dataContext.Departamentos.Where(d => d.nombre.Equals(departamento.nombre));
                if (nuevoDepartamento.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El departamento" + departamento.Id + "ya está registrado", ex);
            }
            return existe;
        }
    }
}