using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO
{
    public class TipoEstadoService: ITipoEstado
    {
        private readonly IDataContext _tipoEstadoContext;
        private readonly IMapper _mapper;
        
        

        public TipoEstadoService(IDataContext tipoestadoContext, IMapper mapper)
        {
            _tipoEstadoContext = tipoestadoContext;
            _mapper = mapper;
           
            
        }

        //GET: Servicio para consultar todos los tipos estados
        public List<TipoEstadoDTO> ConsultaTipoEstados()
        {
            try
            {
                var data = _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).ToList();
                var tipoEstadoSearchDTO = _mapper.Map<List<TipoEstadoDTO>>(data);
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

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public TipoEstadoDTO ConsultarTipoEstadoGUID(Guid id)
        {
            try
            {
                var data = _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(t => t.Id == id).Single();
                var tipoEstadoSearchDTO = _mapper.Map<TipoEstadoDTO>(data);
                return tipoEstadoSearchDTO;
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
                var data = _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(t => t.nombre == titulo).Single();
                var tipoEstadoSearchDTO = _mapper.Map<TipoEstadoDTO>(data);
                return tipoEstadoSearchDTO;
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
                var tipoEstadoCreate = tipoEstado; 
                var tipoEstadoEntity = _mapper.Map<Tipo_Estado>(tipoEstadoCreate);
                tipoEstadoEntity.Id = Guid.NewGuid();
                               

                if (tipoEstado.etiqueta != null && tipoEstado.etiqueta.Count() > 0)
                    tipoEstadoEntity.etiquetaTipoEstado = AñadirRelacionEtiquetaTipoEstado(tipoEstadoEntity.Id, tipoEstado.etiqueta);

                _tipoEstadoContext.Tipos_Estados.Add(tipoEstadoEntity);

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

        //PUT: Servicio para actualizar tipo estado
        public TipoEstadoDTO ActualizarTipoEstado(TipoEstadoUpdateDTO tipoEstadoAct, Guid id)
        {
            try
            {
               
                var tipoEstadoEntity = _tipoEstadoContext.Tipos_Estados.Include(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(et => et.Id == id).Single();
                tipoEstadoEntity.etiquetaTipoEstado.Clear();

                //Actualizar la relación de tipo estado con etiquetas
                if ( tipoEstadoAct.etiqueta.Count() > 0 )
                    tipoEstadoEntity.etiquetaTipoEstado = AñadirRelacionEtiquetaTipoEstado( id, tipoEstadoAct.etiqueta);

                //Si tiene permiso, quiere decir que puede modificar los atributos nombre y descripción del tipo estado
                if (tipoEstadoEntity.permiso)
                {
                    tipoEstadoEntity.nombre = tipoEstadoAct.nombre;
                    tipoEstadoEntity.descripcion = tipoEstadoAct.descripcion;
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

        //DELETE: Servicio para eliminar el tipo estado
        public TipoEstadoCreateDTO EliminarTipoEstado(Guid id)
        {
            try
            {
                var tipoEstado = _tipoEstadoContext.Tipos_Estados.Include(t => t.etiquetaTipoEstado).Where(t => t.Id == id).Single();
                //Si no tiene permiso, quiere decir que no podrá eliminar el tipo estado
                if (!tipoEstado.permiso)
                {
                    throw new ExceptionsControl("No se puede eliminar este tipo de estado por la integridad del sistema");
                }

                //Verifica si hay una plantilla notificación asociada al tipo estado. De ser así, eliminar la relación en plantilla.
                var plantilla = _tipoEstadoContext.PlantillasNotificaciones.Where(p => p.TipoEstadoId == id).FirstOrDefault();
                if (plantilla != null)
                {
                    plantilla.TipoEstadoId = null;
                    _tipoEstadoContext.PlantillasNotificaciones.Update(plantilla);
                }

                
                _tipoEstadoContext.Tipos_Estados.Remove(tipoEstado);
                _tipoEstadoContext.DbContext.SaveChanges();
                return _mapper.Map<TipoEstadoCreateDTO>(tipoEstado);
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("No se puede eliminar este tipo de estado por la integridad del sistema", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("Un ticket está utilizado este tipo de estado, por lo tanto no se puede eliminar", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo eliminar el tipo de estado", ex);
            }

        }

        public HashSet<EtiquetaTipoEstado> AñadirRelacionEtiquetaTipoEstado(Guid tipoEstadoId, HashSet<Guid> etiquetas)
        {
            try
            {
                var listEtiquetaTipoEstado = new HashSet<EtiquetaTipoEstado>();
                foreach (Guid i in etiquetas)
                {
                    var item = new EtiquetaTipoEstado();
                    item.tipoEstadoID = tipoEstadoId;
                    //var resultService = await _etiqueta.ConsultarEtiquetaGUID(i.Id);
                    item.etiquetaID = i;
                    listEtiquetaTipoEstado.Add(item);
                    //_tipoEstadoContext.EtiquetasTipoEstados.Add(item);
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
