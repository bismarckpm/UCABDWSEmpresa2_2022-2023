using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesGenerales;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO
{
    public class TipoEstadoService: ITipoEstado
    {
        private readonly IDataContext _tipoEstadoContext;
        private readonly IMapper _mapper;
        private readonly IEstadoDAO _estadoService;

        public TipoEstadoService(IDataContext tipoestadoContext, IMapper mapper, IEstadoDAO estadoService )
        {
            _tipoEstadoContext = tipoestadoContext;
            _mapper = mapper;
            _estadoService = estadoService;
        }

        public TipoEstadoService(IDataContext tipoestadoContext)
        {
            _tipoEstadoContext = tipoestadoContext;

        }

        //GET: Servicio para consultar todos los tipos estados
        public List<TipoEstadoDTO> ConsultaTipoEstados()
        {
            try
            {
                var tipoEstadoSearchDTO = _mapper.Map<List<TipoEstadoDTO>>(_tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).ToList());
                if (tipoEstadoSearchDTO.Count() == 0)
                    throw new ExceptionsControl("No existen Tipos de estados registrados");
                return tipoEstadoSearchDTO;
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("No existen Tipos de estados registrados", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema en la consulta", ex);
            }
        }

        //GET: Servicio para consultar todos los tipos estados
        public List<TipoEstadoDTO> ConsultaTipoEstadosHabilitados()
        {
            try
            {
                var tipoEstadoSearchDTO = _mapper.Map<List<TipoEstadoDTO>>(_tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(t => t.fecha_eliminacion == null).ToList());
                if (tipoEstadoSearchDTO.Count() == 0)
                    throw new ExceptionsControl("No existen Tipos de estados habilitados");
                return tipoEstadoSearchDTO;
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("No existen Tipos de estados registrados", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema en la consulta", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public TipoEstadoDTO ConsultarTipoEstadoGUID(Guid id)
        {
            try
            {
                return _mapper.Map<TipoEstadoDTO>(_tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(t => t.Id == id).Single());
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe el tipo estado con ese ID", ex);
            }

        }

        //GET: Servicio para consultar una tipo estado por un título específico
        public TipoEstadoDTO ConsultarTipoEstadoTitulo(string titulo)
        {
            try
            {
                return _mapper.Map<TipoEstadoDTO>(_tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(t => t.nombre == titulo).Single());
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la tipo estado con ese título", ex);
            }
        }

        //POST: Servicio para crear tipo estado
        public TipoEstadoCreateDTO RegistroTipoEstado(TipoEstadoCreateDTO tipoEstado)
        {
            try
            {
                var tipoEstadoEntity = _mapper.Map<Tipo_Estado>(tipoEstado);
                tipoEstadoEntity.Id = Guid.NewGuid();
                               
                if ( tipoEstado.etiqueta.Count() > 0)
                    tipoEstadoEntity.etiquetaTipoEstado = AñadirRelacionEtiquetaTipoEstado(tipoEstadoEntity.Id, tipoEstado.etiqueta);

                _tipoEstadoContext.Tipos_Estados.Add(tipoEstadoEntity);

                //Llena la entidad intermedia Estado
                AgregarEstadoATipoEstadoCreado(tipoEstadoEntity);

                _tipoEstadoContext.DbContext.SaveChanges();
                return tipoEstado;
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("Se esta intentando asociar a una etiqueta que no existe", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("alguno de los campos requeridos del tipo de estado está vacio", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar el tipo estado", ex);
            }            
        }

        //Agregar Estados de los Tipo Estados Agregados

        public void AgregarEstadoATipoEstadoCreado(Tipo_Estado estado)
        {
            var listaEstados = new List<Estado>();

            foreach (var departamento in _tipoEstadoContext.Departamentos.ToList())
            {
                listaEstados.Add(new Estado(departamento.nombre + " " + estado.nombre, estado.descripcion)
                {
                    Id = Guid.NewGuid(),
                    Departamento = departamento,
                    Estado_Padre = estado,
                    Bitacora_Tickets = new List<Bitacora_Ticket>(),
                    ListaTickets = new List<Ticket>()
                });
            }

            _tipoEstadoContext.Estados.AddRange(listaEstados);
            _tipoEstadoContext.DbContext.SaveChanges();
        }


        //PUT: Servicio para actualizar tipo estado
        public TipoEstadoDTO ActualizarTipoEstado(TipoEstadoUpdateDTO tipoEstadoAct, Guid id)
        {
            try
            {

                var tipoEstadoEntity = _mapper.Map<Tipo_Estado>(ConsultarTipoEstadoGUID(id));
                tipoEstadoEntity.etiquetaTipoEstado.Clear();

                //Actualizar la relación de tipo estado con etiquetas
                if ( tipoEstadoAct.etiqueta.Count() > 0 )
                    tipoEstadoEntity.etiquetaTipoEstado = AñadirRelacionEtiquetaTipoEstado( id, tipoEstadoAct.etiqueta);

                //Si tiene permiso, quiere decir que puede modificar los atributos nombre y descripción del tipo estado
                if (tipoEstadoEntity.permiso)
                {
                    tipoEstadoEntity.descripcion = tipoEstadoAct.descripcion;
                    tipoEstadoEntity.nombre = tipoEstadoAct.nombre;
                }

                _tipoEstadoContext.Tipos_Estados.Update(tipoEstadoEntity);
                _tipoEstadoContext.DbContext.SaveChanges();
                return _mapper.Map<TipoEstadoDTO>(tipoEstadoEntity);
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("Se esta intentando asociar a una etiqueta que no existe", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("Alguno de los campos requeridos del tipo de estado está vacio", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo actualizar el tipo de estado", ex);
            }

        }

        //PUT: Servicio para eliminar el tipo estado
        public Boolean HabilitarDeshabilitarTipoEstado(Guid id)
        {
            try
            {
                var tipoEstado = _mapper.Map<Tipo_Estado>(ConsultarTipoEstadoGUID(id));
                //Si no tiene permiso, quiere decir que no podrá deshabilitar el tipo estado
                if (!tipoEstado.permiso)
                {
                    throw new ExceptionsControl("No se puede Deshabilitar este tipo de estado por la integridad del sistema");
                }
               
                if(tipoEstado.fecha_eliminacion != null)
                {
                    tipoEstado.fecha_eliminacion = null;  //Hablilitar el tipo estado
                    foreach (Estado hijo in _mapper.Map<List<Estado>>(_estadoService.ConsultarEstadosPorEstadoPadre(tipoEstado.Id)))
                    {
                        _estadoService.HabilitarEstado(hijo.Id);
                    }
                }
                else
                {
                    tipoEstado.fecha_eliminacion = DateTime.Now; //Deshabilitar el tipo estado 
                    foreach (Estado hijo in _mapper.Map<List<Estado>>(_estadoService.ConsultarEstadosPorEstadoPadre(tipoEstado.Id)))
                    {
                        _estadoService.DeshabilitarEstado(hijo.Id);
                    }

                }

                //Verifica si hay una plantilla notificación asociada al tipo estado. De ser así, eliminar la relación en plantilla.
                var plantilla = _tipoEstadoContext.PlantillasNotificaciones.Where(p => p.TipoEstadoId == id).FirstOrDefault();
/*APLICAR OBJETO NULO*/             if ((plantilla != null) && (tipoEstado.fecha_eliminacion != null)) 
                {
                    plantilla.TipoEstadoId = null;
                    _tipoEstadoContext.PlantillasNotificaciones.Update(plantilla);
                }

                _tipoEstadoContext.Tipos_Estados.Update(tipoEstado);
                _tipoEstadoContext.DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo habilitar o deshabilitar el tipo de estado", ex);
            }

        }

        public HashSet<EtiquetaTipoEstado> AñadirRelacionEtiquetaTipoEstado(Guid tipoEstadoId, HashSet<Guid> etiquetas)
        {
            try
            {
                var listEtiquetaTipoEstado = new HashSet<EtiquetaTipoEstado>();
                foreach (Guid idEtiquetas in etiquetas)
                {
                    var item = new EtiquetaTipoEstado();
                    item.tipoEstadoID = tipoEstadoId;
                    item.etiquetaID = idEtiquetas;
                    listEtiquetaTipoEstado.Add(item);
                }
                return listEtiquetaTipoEstado;
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo establecer la relacion entre las etiquetas y el tipo de estado", ex);
                
            }
        }

    }
}
