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
using System.Data;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO
{
    public class DepartamentoDAO : IDepartamentoDAO
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper mapper;

        //Constructor
        public DepartamentoDAO(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            this.mapper = mapper;
        }

        //Registrar un Departamento
        public DepartamentoDto AgregarDepartamentoDAO(Departamento departamento)
        {
            try
            {
                if (!ExisteDepartamento(departamento)) {
                    _dataContext.Departamentos.Add(departamento);
                    _dataContext.DbContext.SaveChanges();
                }

                var nuevoDepartamento = _dataContext.Departamentos.Where(u => u.id == departamento.id).First();

                AgregarEstadoADepartamentoCreado(departamento);
             //   AgregarCargosADepartamentoCreado(departamento);

                return DepartamentoMapper.MapperEntityToDto(nuevoDepartamento);
            }
            catch (Exception ex) {
				throw new ExceptionsControl("No se pudo registrar el departamento"+" "+departamento.nombre, ex);
			}
        }

        //Agregar Estados de los departamentos agregados

        public List<Estado> AgregarEstadoADepartamentoCreado(Departamento departamento)
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
            return listaEstados;
        }

        //Agregar Estados de los departamentos agregados

        /*public List<Cargo> AgregarCargosADepartamentoCreado(Departamento departamento)
        {
            var listaTipoCargos = _dataContext.Tipos_Cargos.ToList();

            var ListaCargos = new List<Cargo>();

            foreach (var TipoCargo in listaTipoCargos)
            {
                ListaCargos.Add(new Cargo(departamento.nombre + " " + TipoCargo.nombre, TipoCargo.descripcion)
                {
                    id = Guid.NewGuid(),
                    Departamento = departamento,
                    Tipo_Cargo = TipoCargo
                });
            }

            _dataContext.Cargos.AddRange(ListaCargos);
            return ListaCargos;
        }*/

        //Eliminar un Departamento
        public DepartamentoDto eliminarDepartamento(Guid id)
        {
            try
            {
				var departamento = _dataContext.Departamentos
                           .Where(d => d.id == id).First();


					departamento.fecha_eliminacion = DateTime.Now.Date;
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
                if (!ExisteDepartamentoModificar(departamento)) {
                    _dataContext.Departamentos.Update(departamento);
                    _dataContext.DbContext.SaveChanges();
                }

                    var data = _dataContext.Departamentos.Where(u => u.id == departamento.id && u.nombre == departamento.nombre).First();               
                    return DepartamentoMapper.MapperEntityToDTOModificar(data);
            }           
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("Fallo al actualizar el departamento: "+departamento.nombre, ex);
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

        public List<DepartamentoDto> NoAsociado()
        {
			try
			{
				var lista = _dataContext.Departamentos.Where(x => x.id_grupo == null && x.fecha_eliminacion==null).Select(
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

        public bool ExisteDepartamento(Departamento departamento)
        {
            
            bool existe = false;

            try
            {
                var nuevoDepartamento = _dataContext.Departamentos.Where(d => d.nombre.Equals(departamento.nombre) && d.fecha_eliminacion == null);
                if (nuevoDepartamento.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El departamento" + departamento.id + "ya está registrado", ex);
            }
            return existe;
        } 

        public IEnumerable<DepartamentoSearchDTO> ConsultaDepartamentoExcluyente(Guid IdDepartamento)
        {
           var ListaDepartamento = mapper.Map<List<DepartamentoSearchDTO>>(_dataContext.Departamentos.Where(x => x.id != IdDepartamento).ToList());
           return ListaDepartamento;       
        }

        public bool ExisteDepartamentoModificar(Departamento dept)
        {
            bool existe = false;

            try
            {
                //Lista de departamentos que no tienen el ID del departamento a modificar y no están eliminados
                var buscarDepartamentoDiferente = _dataContext.Departamentos.Where(d => (d.id != dept.id) && (d.fecha_eliminacion == null)).ToList();

                //Lista de los departamentos que tienen el mismo nombre que el departamento a modificar
                var buscarDepartamentoMismoNombre = buscarDepartamentoDiferente.Where(d => d.nombre == dept.nombre).ToList();

                if (buscarDepartamentoMismoNombre.Count() != 0)
                    existe = true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se encuentra el departamento" + " " + dept.id, ex);
            }
            return existe;
        }
    }
}