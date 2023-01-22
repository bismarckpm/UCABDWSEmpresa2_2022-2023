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
        /// <summary>
        /// Declaración de variables.
        /// </summary>
       
        private readonly IDataContext _dataContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor. Inicializa la variable _dataContext
        /// </summary>
        /// <param name="dataContext">Ingresa un objeto de la interfaz DataContext</param>
        /// <param name="mapper">Ingresa un objeto de la interfaz IMapper</param>
        public DepartamentoDAO(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// Método que permite agregar un nuevo departamento, y asignar 
        /// un estado a un departamento previamente creado,
        /// si este tiene un nombre que ya existe devuelve un objeto nulo.
        /// </summary>
        /// <param name="departamento">Ingresa un objeto del tipo Departamento</param>
        /// <returns>Devuelve un objeto del tipo DepartamentoDto</returns>
        /// <exception cref="ExceptionsControl">En caso que el parametro sea nulo, muestra la excepción</exception>
        public DepartamentoDto AgregarDepartamentoDAO(Departamento departamento)
        {
            try
            {
                if (!ExisteDepartamento(departamento)) {
                    departamento.fecha_creacion = DateTime.Now.Date;
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

        /// <summary>
        /// Método que elimina un departamento y agrega la fecha 
        /// actual en la columna de fecha_eliminacion.
        /// </summary>
        /// <param name="id">Ingresa un identificador de un departamento</param>
        /// <returns>Devuelve un objeto de tipo DepartamentoDto</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
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

        /// <summary>
        /// Método que modifica y almacena los valores de un departamento, solo si el 
        /// nombre modificado no esté registrado previamente.
        /// </summary>
        /// <param name="departamento">Ingresa un objeto del tipo departamento.</param>
        /// <returns>Devuelve un objeto del tipo DepartamentoDto_Update con los cambios realizados.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
        public DepartamentoDto_Update ActualizarDepartamento(Departamento departamento)
        {
            try
            {
                if (!ExisteDepartamentoModificar(departamento)) {
                    departamento.fecha_ultima_edicion = DateTime.Now.Date;
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

        /// <summary>
        /// Método que consulta por ID los valores de un departamento
        /// </summary>
        /// <param name="id">Ingresa un identificador de un departamento</param>
        /// <returns>Devuelve un objeto del tipo DepartamentoDto.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
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

        /// <summary>
        /// Método que lista todos los departamentos existentes y eliminados en el sistema.
        /// </summary>
        /// <returns>Devuelve una lista de objetos del tipo DepartamentoDto.</returns>
        /// <exception cref="ExceptionsControl">En caso que no haya departamentos registrados..</exception>

        public List<DepartamentoDto> ConsultarDepartamentos()
        {
            try
            {
                var lista = _dataContext.Departamentos.Select(
                    d => new DepartamentoDto
                    {
                        Id = d.id,
                        Nombre = d.nombre,
                        Descripcion = d.descripcion,
                        Fecha_creacion = d.fecha_creacion,
                        Fecha_ultima_edicion = d.fecha_ultima_edicion,
                        Fecha_eliminacion = d.fecha_eliminacion

                    }
                );

                return lista.ToList();
                
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No hay departamentos registrados", ex);
            }
        }

        /// <summary>
        /// Método que consulta todos los departamentos que están activos.
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo DepartamentoDto.</returns>
        /// <exception cref="ExceptionsControl">En caso que no haya departamentos registrados.</exception>
		public List<DepartamentoDto> DepartamentosNoEliminados()
		{
			try
			{

				var lista = _dataContext.Departamentos.Where(x => x.fecha_eliminacion == null).Select(
					d => new DepartamentoDto
					{
						Id = d.id,
						Nombre = d.nombre,
						Descripcion = d.descripcion,
						Fecha_creacion = d.fecha_creacion,
						Fecha_ultima_edicion = d.fecha_ultima_edicion,
						Fecha_eliminacion = d.fecha_eliminacion

					}
				);

				return lista.ToList();

			}
			catch (Exception ex)
			{
				throw new ExceptionsControl("No hay departamentos registrados", ex);
			}
		}

        /// <summary>
        /// Método que lista todos los departamentos no asociados a un grupo.
        /// </summary>
        /// <returns>Devuelve una lista de objetos del tipo DepartamentoDto.</returns>
        /// <exception cref="ExceptionsControl">En caso que no haya departamentos registrados.</exception>
        public List<DepartamentoDto> NoAsociado()
        {
			try
			{
				var lista = _dataContext.Departamentos.Where(x => x.id_grupo == null && x.fecha_eliminacion==null).Select(
					d => new DepartamentoDto
					{
						Id = d.id,
						Nombre = d.nombre,
						Descripcion = d.descripcion,
						Fecha_creacion = d.fecha_creacion,
						Fecha_ultima_edicion = d.fecha_ultima_edicion,
						Fecha_eliminacion = d.fecha_eliminacion
					}
				);
				return lista.ToList();
			}
			catch (Exception ex)
			{
				throw new ExceptionsControl("No hay departamentos registrados", ex);
			}
		}

        /// <summary>
        /// Método que verifica si el nombre del departamento esta activo y ya existe en el sistema.
        /// </summary>
        /// <param name="departamento">Ingresa un objeto de tipo de Departamento.</param>
        /// <returns>Devuelve un tipo de dato bool.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
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

        /// <summary>
        /// Método que verifica si el nuevo nombre del departamento ya está registrado.
        /// </summary>
        /// <param name="dept">Ingresa un objeto de tipo de Departamento, contiene los datos a almacenar.</param>
        /// <returns>Devuelve un tipo de dato bool.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>

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