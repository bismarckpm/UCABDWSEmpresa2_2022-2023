using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
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
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO
{
    public class TipoEstadoService: ITipoEstado
    {
        private readonly IDataContext _tipoEstadoContext;
        private readonly IMapper _mapper;
        private readonly IEtiqueta _etiqueta;
        

        public TipoEstadoService(DataContext tipoestadoContext, IMapper mapper, IEtiqueta etiqueta)
        {
            _tipoEstadoContext = tipoestadoContext;
            _mapper = mapper;
            _etiqueta = etiqueta;
            
        }

        //GET: Servicio para consultar todos los tipos estados
        public async Task<List<TipoEstadoDTO>> ConsultaTipoEstados()
        {
            try
            {
                var data = await _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).ToListAsync();
                var tipoEstadoSearchDTO = _mapper.Map<List<TipoEstadoDTO>>(data);
                return tipoEstadoSearchDTO;
            }catch(Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema en la consulta", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public async Task<TipoEstadoDTO> ConsultarTipoEstadoGUID(Guid id)
        {
            try
            {
                var data = await _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(t => t.Id == id).SingleAsync();
                var tipoEstadoSearchDTO = _mapper.Map<TipoEstadoDTO>(data);
                return tipoEstadoSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe el tipo estado con ese ID", ex);
            }

        }

        //GET: Servicio para consultar una tipo estado por un título específico
        public async Task<TipoEstadoDTO> ConsultarTipoEstadoTitulo(string titulo)
        {
            try
            {
                var data = await _tipoEstadoContext.Tipos_Estados.AsNoTracking().Include(t => t.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(t => t.nombre == titulo).SingleAsync();
                var tipoEstadoSearchDTO = _mapper.Map<TipoEstadoDTO>(data);
                return tipoEstadoSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la tipo estado con ese título", ex);
            }
        }

        //POST: Servicio para crear tipo estado
        public async Task<Boolean> RegistroTipoEstado(TipoEstadoCreateDTO tipoEstado)
        {
            try
            {
                var tipoEstadoCreate = tipoEstado; 
                var tipoEstadoEntity = _mapper.Map<Tipo_Estado>(tipoEstadoCreate);
                tipoEstadoEntity.Id = Guid.NewGuid();
                               

                if (tipoEstado.etiqueta != null && tipoEstado.etiqueta.Count() > 0)
                    tipoEstadoEntity.etiquetaTipoEstado = AñadirRelacionEtiquetaTipoEstado(tipoEstadoEntity.Id, tipoEstado.etiqueta);

                _tipoEstadoContext.Tipos_Estados.Add(tipoEstadoEntity);

                await _tipoEstadoContext.DbContext.SaveChangesAsync();
                return true;
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
        public async Task<Boolean> ActualizarTipoEstado(TipoEstadoUpdateDTO tipoEstadoAct, Guid id)
        {
            try
            {
               
                var tipoEstadoEntity = await _tipoEstadoContext.Tipos_Estados.Include(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(et => et.Id == id).SingleAsync();
                tipoEstadoEntity.etiquetaTipoEstado.Clear();

                if (tipoEstadoAct.etiqueta!=null && tipoEstadoAct.etiqueta.Count() > 0 )
                    tipoEstadoEntity.etiquetaTipoEstado = AñadirRelacionEtiquetaTipoEstado( id, tipoEstadoAct.etiqueta);

                tipoEstadoEntity.nombre = tipoEstadoAct.nombre;
                tipoEstadoEntity.descripcion = tipoEstadoAct.descripcion;
                _tipoEstadoContext.Tipos_Estados.Update(tipoEstadoEntity);
                await _tipoEstadoContext.DbContext.SaveChangesAsync();
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
        public async Task<Boolean> EliminarTipoEstado(Guid id)
        {
            try
            {
              
                var plantilla = await _tipoEstadoContext.PlantillasNotificaciones.Where(p => p.TipoEstadoId == id).FirstOrDefaultAsync();
                if (plantilla != null)
                {
                    plantilla.TipoEstadoId = null;
                    _tipoEstadoContext.PlantillasNotificaciones.Update(plantilla);
                }
                var tipoEstado = await _tipoEstadoContext.Tipo_Estados.Include(t => t.etiquetaTipoEstado).Where(t => t.Id == id).SingleAsync();
                _tipoEstadoContext.Tipo_Estados.Remove(tipoEstado);
                await _tipoEstadoContext.DbContext.SaveChangesAsync();
                return true;
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
