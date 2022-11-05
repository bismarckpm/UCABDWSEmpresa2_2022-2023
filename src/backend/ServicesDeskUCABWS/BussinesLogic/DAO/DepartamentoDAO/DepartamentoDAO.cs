using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;

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

                _dataContext.Departamentos.Add(departamento);
                _dataContext.SaveChanges();

                var nuevoDepartamento = _dataContext.Departamentos.Where(d => d.id == departamento.id)
                                        .Select(d => new DepartamentoDto
                                        {
                                            Id = d.id,
                                            descripcion = d.descripcion,
                                            nombre = d.nombre,
                                            fecha_creacion = d.fecha_creacion
                                        });

                return nuevoDepartamento.First();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " : " + ex.StackTrace);
                throw ex.InnerException!;
            }
        }

        //Eliminar un Departamento
        public DepartamentoDto eliminarDepartamento(Guid id)
        {
            try
            {
                var departamento = _dataContext.Departamentos
                .Where(d => d.id == id).First();

                _dataContext.Departamentos.Remove(departamento);
                _dataContext.SaveChanges();

                return DepartamentoMapper.MapperEntityToDto(departamento);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al eliminar por id: " + id, ex);
            }
        }

        //Actualizar departamentos
        public DepartamentoDto_Update ActualizarDepartamento(Departamento departamento)
        {
            try
            {
                _dataContext.Departamentos.Update(departamento);
                _dataContext.SaveChanges();

                var data = _dataContext.Departamentos.Where(d => d.id == departamento.id).Select(
                    d => new DepartamentoDto_Update
                    {
                        Id = d.id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion
                    }

                );
                return data.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " || " + ex.StackTrace);
                throw new Exception("Fallo al actualizar: " + departamento.id, ex);
            }
        }

        //Consultar Departamento por ID
        public DepartamentoDto ConsultarPorID(Guid id)
        {
            var departamento = _dataContext.Departamentos
                .Where(d => d.id == id).First();

            return DepartamentoMapper.MapperEntityToDtoDefault(departamento);
        }


        //Consultar departamentos

        public List<DepartamentoDto> ConsultarDepartamentos()
        {
            try
            {
                var lista = _dataContext.Departamentos.Select(
                    d => new DepartamentoDto
                    {
                        Id = d.id,
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

        


    }
}

    
