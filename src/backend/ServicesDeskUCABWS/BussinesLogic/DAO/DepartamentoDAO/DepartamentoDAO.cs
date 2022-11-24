using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
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

namespace ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO
{
    public class DepartamentoDAO : IDepartamentoDAO
    {
        private readonly IDataContext _dataContext;
        private readonly IGrupoDAO _servicioGrupo;

        //Constructor
        public DepartamentoDAO(IDataContext dataContext, IGrupoDAO servicioGrupo)
        {
            _dataContext = dataContext;
            _servicioGrupo = servicioGrupo;
        }

		//Registrar un Departamento
		public DepartamentoDto AgregarDepartamentoDAO(Departamento departamento)
        {
            try
            {

                    _dataContext.Departamentos.Add(departamento);
				_dataContext.DbContext.SaveChanges();


				var nuevoDepartamento = _dataContext.Departamentos.Where(d => d.id == departamento.id)
						.Select(d => new DepartamentoDto
						{
							id = d.id,
							descripcion = d.descripcion,
							nombre = d.nombre,
							fecha_creacion = d.fecha_creacion

						}).First();

				return nuevoDepartamento;
			}
            catch (Exception ex) {
				throw new ExceptionsControl("No se pudo registrar el departamento"+" "+departamento.nombre, ex);
			}
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
					_dataContext.DbContext.SaveChanges();

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
				_dataContext.DbContext.SaveChanges();

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
				throw new ExceptionsControl("No hay departamentos eliminados", ex);
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

        public List<string> AsignarGrupoToDepartamento(Guid id,string idDept)
        {

            try
            {
				List<string> listaDept = idDept.Split(',').ToList();


                foreach (var dept in listaDept)
                {

					var nuevoDepartamento = _dataContext.Departamentos.Where(d => d.id.ToString() == dept).FirstOrDefault();
                    nuevoDepartamento.id_grupo = id;
					_dataContext.DbContext.SaveChanges();

				}

                return listaDept;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Fallo al asignar grupo", ex);
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

        //Retorna una lista de departamentos que no están asociados a un grupo
        public List<DepartamentoDto> NoAsociado()
        {
			try
			{
				var lista = _dataContext.Departamentos.Where(x => x.id_grupo == null && x.fecha_eliminacion == null).Select(
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
				throw new ExceptionsControl("No hay departamentos asociados", ex);
			}
		}

        public List<string> EditarRelacion(Guid id, string idDepartamentos)
        {
            try
            {
                List<string> listaDept = idDepartamentos.Split(',').ToList();

                if (idDepartamentos.Equals("")) {

                    _servicioGrupo.QuitarAsociacion(id);

                    return listaDept;

                }else if(_servicioGrupo.QuitarAsociacion(id)) {

                    foreach (var nuevoDept in listaDept) {

                        var relacionado = _dataContext.Departamentos.Where(x => x.id.ToString() == nuevoDept).FirstOrDefault();
                        if (relacionado != null) {
                            relacionado.id_grupo = id;
                            relacionado.fecha_ultima_edicion = DateTime.Now.Date;
							_dataContext.DbContext.SaveChanges();
						}

                    }
                
                }
                return listaDept;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Fallo al asignar grupo", ex);
            }
		}
    }
}