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


        /// <summary>
        /// Constructor. Inicializa la variable _dataContext
        /// </summary>
        /// <param name="dataContext">Ingresa un objeto de la interfaz DataContext</param>

        public GrupoDAO(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Método que permite agregar un nuevo grupo,
        /// si este tiene un nombre que ya existe devuelve un objeto nulo.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto del tipo Grupo</param>
        /// <returns>Devuelve un objeto del tipo GrupoDto</returns>
        /// <exception cref="ExceptionsControl">En caso que el parametro sea nulo, muestra la excepción</exception>
        
        public GrupoDto AgregarGrupoDao(Grupo grupo)
        {
            try
            {
                if (!ExisteGrupo(grupo)) {
                    _dataContext.Grupos.Add(grupo);
                    _dataContext.DbContext.SaveChanges();
                }
                return GrupoMapper.MapperEntityToDto(_dataContext.Grupos.Where(d => d.id == grupo.id).First());
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error al momento de registrar", ex);
            }
        }

        /// <summary>
        /// Método que busca un grupo a partir de un identificador.
        /// </summary>
        /// <param name="idGrupo">Ingresa el identificador de un grupo en específico</param>
        /// <returns>Devuelve un objeto del tipo GrupoDto</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo</exception>
        
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

        /// <summary>
        /// Método que agrega la fecha actual en la columna de fecha_eliminacion.
        /// Consulta el grupo por su identificador, al haber hecho el cambio,
        /// se elimina la relación con los departamentos asociados.
        /// </summary>
        /// <param name="idGrupo">Ingresa un identificador de un grupo</param>
        /// <returns>Devuelve un objeto de tipo GrupoDto</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
        
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

        /// <summary>
        /// Método que modifica y almacena los valores de un grupo. 
        /// En caso que el nombre modificado no esté registrado.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto del tipo grupo.</param>
        /// <returns>Devuelve un objeto del tipo GrupoDto_Update con los cambios realizados.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
        
        public GrupoDto_Update ModificarGrupoDao(Grupo grupo)
        {
            try
            {

				if (!ExisteGrupoModificar(grupo))
				{
					_dataContext.Grupos.Update(grupo);
					_dataContext.DbContext.SaveChanges();
				}

                return GrupoMapper.MapperEntityToDTOUpdate(_dataContext.Grupos.Where(d => d.id == grupo.id && d.nombre == grupo.nombre).First());
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
        /// <summary>
        /// Método que establece en nulo la columna de id_grupo en la tabla departamentos,
        /// Consulta los departamentos que están asociados a un grupo.
        /// </summary>
        /// <param name="grupoId">Ingresa el identificador de un grupo</param>
        /// <returns>Devuelve un valor booleano</returns>

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

        /// <summary>
        /// Método que consulta todos los grupos que están activos.
        /// </summary>
        /// <returns>Devuelve una lista de objetos de tipo grupoDto.</returns>
        /// <exception cref="ExceptionsControl">En caso que no haya grupos registrados.</exception>
        
        public List<GrupoDto> ConsultarGrupoNoEliminado()
        {
            try
            {
                var lista = _dataContext.Grupos.Where(x => x.fecha_eliminacion == null).Select(
                    d => new GrupoDto
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
                throw new ExceptionsControl("No hay grupos eliminados", ex);
            }
        }

        /// <summary>
        /// Método que verifica si el grupo que se va a registrar ya esté activo.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto de tipo de Grupo, contiene los datos a almacenar.</param>
        /// <returns>Devuelve un tipo de dato bool.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>

        public bool ExisteGrupo(Grupo grupo)
        {
            bool existe = false;

            try
            {
                var nuevoGrupo = _dataContext.Grupos.Where(d => d.nombre.Equals(grupo.nombre) && d.fecha_eliminacion == null);
                if (nuevoGrupo.Count() != 0)
                    existe = true;
            }
			catch (Exception ex)
			{
				throw new ExceptionsControl("No se encuentra el grupo" + " " + grupo.id, ex);
			}
			return existe;
        }

        /// <summary>
        /// Método que verifica si el nuevo nombre del grupo ya está registrado.
        /// </summary>
        /// <param name="grupo">Ingresa un objeto de tipo de Grupo, contiene los datos a almacenar.</param>
        /// <returns>Devuelve un tipo de dato bool.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>

        public bool ExisteGrupoModificar(Grupo grupo)
		{
			bool existe = false;

			try
			{
                //Lista de grupos que no tienen el ID del grupo a modificar y no están eliminados
				var buscarGrupoDiferente = _dataContext.Grupos.Where(d => (d.id != grupo.id) && (d.fecha_eliminacion == null)).ToList();
                
                //Lista de los grupos que tienen el mismo nombre que el grupo a modificar
                var buscarGrupoMismoNombre = buscarGrupoDiferente.Where(d => d.nombre == grupo.nombre).ToList();
             
                if (buscarGrupoMismoNombre.Count() != 0)
					existe = true;
			}
			catch (Exception ex)
			{
				throw new ExceptionsControl("No se encuentra el grupo" + " " + grupo.id, ex);
			}
			return existe;
		}

        /// <summary>
        /// Método que asocia departamentos a un grupo.
        /// Establece un identificador de un grupo en la columna id_grupo de la tabla departamentos.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <param name="idDept">Lista de identificadores de departamentos.</param>
        /// <returns>Devuelve una lista de identificadores de departamentos.</returns>
        /// <exception cref="ExceptionsControl">En caso que el identificador de grupo sea nulo.</exception>

        public List<string> AsignarGrupoToDepartamento(Guid id, string idDept)
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
                throw new ExceptionsControl("Fallo al asignar departamento", ex);
            }
        }

        /// <summary>
        /// Método que modifica (agrega o elimina) la relación de los departamentos con un grupo.
        /// </summary>
        /// <param name="id">Identificador de un grupo.</param>
        /// <param name="idDepartamentos">Lista de identificadores de departamentos.</param>
        /// <returns>Devuelve una lista de identificadores de los departamentos.</returns>
        /// <exception cref="ExceptionsControl">En caso que el identificador del grupo sea nulo.</exception>

        public List<string> EditarRelacion(Guid id, string idDepartamentos)
        {
            try
            {
                List<string> listaDept = idDepartamentos.Split(',').ToList();

                if (idDepartamentos.Equals(""))
                {

                    QuitarAsociacion(id);

                    return listaDept;

                }
                else if (QuitarAsociacion(id))
                {

                    foreach (var nuevoDept in listaDept)
                    {

                        var relacionado = _dataContext.Departamentos.Where(x => x.id.ToString() == nuevoDept).FirstOrDefault();
                        if (relacionado != null)
                        {
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

        /// <summary>
        /// Método que consulta los departamentos asociados a un grupo.
        /// </summary>
        /// <param name="idGrupo">Ingresa un identificador de un grupo.</param>
        /// <returns>Devuelve una lista de objetos de tipo DepartamentoDto.</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
        
        public List<DepartamentoDto> GetByIdDepartamento(Guid idGrupo)
        {
            try
            {

                var departamentos = _dataContext.Departamentos.Where(grupo => grupo.id_grupo == idGrupo).Select(
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
                return departamentos.ToList();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El departamento" + idGrupo + "No esta registrado", ex);
            }
        }

        /// <summary>
        /// Método que consulta por el nombre de un grupo que esté activo.
        /// </summary>
        /// <param name="nombreGrupo">Ingresa el nombre de un grupo</param>
        /// <returns>Devuelve un objeto de tipo GrupoDto</returns>
        /// <exception cref="ExceptionsControl">En caso que el parámetro sea nulo.</exception>
        
        public GrupoDto buscarGrupoNombre(string nombreGrupo) {
            try
            {
                var resultado = _dataContext.Grupos.Where(grupo => grupo.nombre == nombreGrupo && grupo.fecha_eliminacion == null).First();
                return GrupoMapper.MapperEntityToDtoDefault(resultado);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El grupo " + nombreGrupo + "No esta registrado", ex);
            }
        }


    }
}