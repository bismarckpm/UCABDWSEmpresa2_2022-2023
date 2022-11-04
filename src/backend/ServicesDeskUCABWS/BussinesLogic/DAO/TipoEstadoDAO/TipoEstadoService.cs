using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ServicesDeskUCABWS.BussinessLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO
{
    public class TipoEstadoService: ITipoEstado
    {
        private readonly DataContext _tipoEstadoContext;
        private readonly IMapper _mapper;
        private readonly IEtiqueta _etiqueta;
        

        public TipoEstadoService(DataContext tipoestadoContext, IMapper mapper, IEtiqueta etiqueta)
        {
            _tipoEstadoContext = tipoestadoContext;
            _mapper = mapper;
            _etiqueta = etiqueta;
            
        }

        //GET: Servicio para consultar todos los tipos estados
        public List<TipoEstadoDTO> ConsultaTipoEstados()
        {
            try
            {
                var data = _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta);
                var tipoEstadoSearchDTO = _mapper.Map<List<TipoEstadoDTO>>(data);
                return tipoEstadoSearchDTO.ToList();
            }catch(Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema en la consulta", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public TipoEstadoDTO ConsultarTipoEstadoGUID(Guid id)
        {
            try
            {
                var data = _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).Where(t => t.Id == id).Single();
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
                var data = _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).Where(t => t.nombre == titulo).Single();
                var tipoEstadoSearchDTO = _mapper.Map<TipoEstadoDTO>(data);
                return tipoEstadoSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la tipo estado con ese título", ex);
            }
        }

        //POST: Servicio para crear tipo estado
        public Boolean RegistroTipoEstado(TipoEstadoDTO tipoEstado)
        {
            try
            {
                var tipoEstadoCreate = tipoEstado;
               // tipoEstadoCreate.etiqueta.Clear(); 
                var tipoEstadoEntity = _mapper.Map<Tipo_Estado>(tipoEstadoCreate);
                tipoEstadoEntity.Id = Guid.NewGuid();
                _tipoEstadoContext.Tipos_Estados.Add(tipoEstadoEntity);
                

                if (tipoEstado.etiqueta != null && tipoEstado.etiqueta.Count() > 0)
                    AñadirRelacionEtiquetaTipoEstado(tipoEstadoEntity.Id, tipoEstado.etiqueta); 
                
                _tipoEstadoContext.SaveChanges();
                return true;
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("Se esta intentando asociar a una etiqueta que no existe", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new ExceptionsControl("Se esta intentando asociar a la misma etiqueta mas de una vez", ex);
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
        public Boolean ActualizarTipoEstado(TipoEstadoDTO tipoEstadoAct, Guid id)
        {
            try
            {
               
                var tipoEstadoEntity = _tipoEstadoContext.Tipos_Estados.Include(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(et => et.Id == id).Single();
                tipoEstadoEntity.etiquetaTipoEstado.Clear();
                _tipoEstadoContext.SaveChanges();

                if (tipoEstadoAct.etiqueta!=null && tipoEstadoAct.etiqueta.Count() > 0)
                    AñadirRelacionEtiquetaTipoEstado( id, tipoEstadoAct.etiqueta);

                tipoEstadoEntity.nombre = tipoEstadoAct.nombre;
                tipoEstadoEntity.descripcion = tipoEstadoAct.descripcion;
                _tipoEstadoContext.Tipos_Estados.Update(tipoEstadoEntity);
                _tipoEstadoContext.SaveChanges();
                return true;
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("Se esta intentando asociar a una etiqueta que no existe", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new ExceptionsControl("Se esta intentando asociar a la misma etiqueta mas de una vez", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("alguno de los campos requeridos del tipo de estado está vacio", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo actualizar el tipo de estado", ex);
            }

        }

        //DELETE: Servicio para eliminar el tipo estado
        public Boolean EliminarTipoEstado(Guid id)
        {
            try
            {
              
                var plantilla = _tipoEstadoContext.PlantillasNotificaciones.Where(p => p.TipoEstadoId == id).FirstOrDefault();
                if (plantilla != null)
                {
                    plantilla.TipoEstadoId = null;
                    _tipoEstadoContext.PlantillasNotificaciones.Update(plantilla);
                }
                var tipoEstado = _tipoEstadoContext.Tipo_Estados.Include(t => t.etiquetaTipoEstado).Where(t => t.Id == id).Single();
                _tipoEstadoContext.Tipo_Estados.Remove(tipoEstado);
                _tipoEstadoContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo eliminar el tipo de estado", ex);
            }

        }

        private void AñadirRelacionEtiquetaTipoEstado(Guid tipoEstadoId, HashSet<EtiquetaDTO> etiquetas)
        {
            try
            {
                foreach (EtiquetaDTO i in etiquetas)
                {

                    var item = new EtiquetaTipoEstado();
                    item.tipoEstadoID = tipoEstadoId;
                    item.etiquetaID = _etiqueta.ConsultarEtiquetaGUID(i.Id).Id;
                    _tipoEstadoContext.EtiquetasTipoEstados.Add(item);

                }
                _tipoEstadoContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo establecer la relacion entre las etiquetas y el tipo de estado", ex);
                
            }
        }
    }
}
