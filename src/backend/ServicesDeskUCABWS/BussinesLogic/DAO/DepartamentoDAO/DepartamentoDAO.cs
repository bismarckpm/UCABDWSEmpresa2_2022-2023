using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperDepartamento;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

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

				var nuevoDepartamento = _dataContext.Departamentos.Where(d => d.id == departamento.id)
						.Select(d => new DepartamentoDto
						{
							id = d.id,
							descripcion = d.descripcion,
							nombre = d.nombre,
							fecha_creacion = d.fecha_creacion

						}).First();

                AgregarEstadoADepartamentoCreado(departamento);

                return nuevoDepartamento;
			}
            catch (Exception ex) {
				throw new ExceptionsControl("No se pudo registrar el departamento"+" "+departamento.nombre, ex);
			}
        }

        //Agregar Estados de los departamentos agregados

        public void AgregarEstadoADepartamentoCreado(Departamento departamento)
        {
            var listaTipoEstados = _dataContext.Tipos_Estados.ToList();

            var listaEstados = new List<Estado>();

            foreach (var TipoEstado in listaTipoEstados)
            {
                listaEstados.Add(new Estado(departamento.nombre + " " + TipoEstado.nombre, TipoEstado.descripcion)
                {
                    Id = Guid.NewGuid(),
                    Departamento = departamento,
                    Estado_Padre = TipoEstado,
                    Bitacora_Tickets = new List<Bitacora_Ticket>(),
                    ListaTickets = new List<Ticket>()
                });
            }

            _dataContext.Estados.AddRange(listaEstados);
            _dataContext.DbContext.SaveChanges();
        }

        //Eliminar un Departamento
        public DepartamentoDto eliminarDepartamento(Guid id)
        {
            try
            {
				var departamento = _dataContext.Departamentos
                           .Where(d => d.id == id).First();


					departamento.fecha_eliminacion = DateTime.Now.Date;
					departamento.id_grupo = null;
					_dataContext.SaveChanges();

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
                    _dataContext.Departamentos.Update(departamento);
                    _dataContext.SaveChanges();

                var data = _dataContext.Departamentos.Where(d => d.id == departamento.id).Select(
                    d => new DepartamentoDto_Update
                    {
                        id = d.id,
                        nombre = d.nombre,
                        descripcion = d.descripcion,
                        fecha_ultima_edicion = d.fecha_ultima_edicion
                    }

                );
                return data.First();
            }
            catch (Exception ex)
            {
				throw new ExceptionsControl("No se encuentra el departamento" + " " + departamento.id, ex);
			}
        }

        //Consultar Departamento por ID
        public DepartamentoDto ConsultarPorID(Guid id)
        {
            try {

				var departamento = _dataContext.Departamentos
			   .Where(d => d.id == id).First();
				return DepartamentoMapper.MapperEntityToDtoDefault(departamento);
                
			}
            catch (Exception ex) { 
				throw new ExceptionsControl("No se encuentra el departamento" +" "+ id, ex);
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
				throw new ExceptionsControl("No hay departamentos registrados", ex);
			}
		}

		//Listar departamentos por el identificador de un grupo
		public List<DepartamentoDto> GetByIdDepartamento(Guid idGrupo)
        {
            try {

                var departamentos = _dataContext.Departamentos.Where(grupo => grupo.id_grupo == idGrupo).Select(
                        d => new DepartamentoDto
                        {
                            id = d.id,
                            nombre = d.nombre,
                            descripcion = d.descripcion,
                            fecha_creacion = d.fecha_creacion,
                            fecha_ultima_edicion = d.fecha_ultima_edicion,
                            fecha_eliminacion = d.fecha_eliminacion
                        }
                     );
			return departamentos.ToList();
            }
            catch (Exception ex) {
				throw new ExceptionsControl("El departamento"+idGrupo+"No esta registrado" , ex);
			}
        }

        public Departamento AsignarGrupoToDepartamento(Guid idGrupo, Guid idDept)
        {
            try
            {
                Departamento result = (from dept in _dataContext.Departamentos
                                       where dept.id == idDept
                                       select dept).SingleOrDefault();

                if (result is not null)
                {
                    result.id_grupo = idGrupo;
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
                if (nuevoDepartamento.Count() != 0 )
                    existe = true;       
            }
            catch (Exception ex) {
				throw new ExceptionsControl("El departamento" + departamento.id + "ya está registrado", ex);
			}
            return existe;
		}

        public List<DepartamentoDto> NoAsociado()
        {
			try
			{
				var lista = _dataContext.Departamentos.Where(x => x.id_grupo == null).Select(
					d => new DepartamentoDto
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
				throw new ExceptionsControl("No hay departamentos registrados", ex);
			}
		}

		public IEnumerable<SelectListItem> ListaDepartamentoGrupo()
        {
			IEnumerable<SelectListItem> listaDept;
            try
            {
				listaDept = _dataContext.Departamentos.Where(x => x.id_grupo == null && x.fecha_eliminacion == null)
	                .Select(x => new SelectListItem
	                   {    
		                    Text = x.nombre,
		                    Value = Convert.ToString(x.id)
	                    }).ToList();

			}
            catch (Exception ex)
            {
				throw new ExceptionsControl("Algo salio mal", ex);
			}
			return listaDept;
        }
        public Departamento obtenerDepartamentoPorEmpleadoId(Guid empleadoId)
        {
            try
            {
                Empleado empleado = _dataContext.Empleados.Include(t => t.Cargo).Where(t => t.Id == empleadoId).Single();
                if (empleado == null)
                    throw new Exception("Empleado no se encuentra registrado en sistema");
                if (empleado.Cargo == null)
                    throw new Exception("Empleado no tiene cargo asignado en el sistema");
                Cargo cargo = _dataContext.Cargos.Include(t => t.Departamento).Where(t => t.Id == empleado.Cargo.Id).Single();
                if (cargo.Departamento == null)
                    throw new Exception("El cargo del empleado no se encuentra asignado a ningún departamento");
                return cargo.Departamento; 
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}