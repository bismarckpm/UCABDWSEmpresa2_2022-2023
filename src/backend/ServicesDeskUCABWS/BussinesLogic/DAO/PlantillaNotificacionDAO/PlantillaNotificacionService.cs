using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacioneDAO
{
    public class PlantillaNotificacionService : IPlantillaNotificacion
    {
        private readonly IDataContext _plantillaContext;
        private readonly INotificacion _notificacionService;
        private readonly IMapper _mapper;
       

        public PlantillaNotificacionService(IDataContext plantillaContext, IMapper mapper, INotificacion notificacionService)
        {
            _plantillaContext = plantillaContext;
            _notificacionService = notificacionService;
            _mapper = mapper;
            
        }

        //GET: Servicio para consultar todas las plantillas
        public  List<PlantillaNotificacionDTO> ConsultaPlantillas()
        {
            try
            {
                var data =  _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).ToList();
                var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionDTO>>(data);
                if (plantillaSearchDTO.Count() == 0)
                    throw new ExceptionsControl("No existen plantillas registradas");
                return plantillaSearchDTO;
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("No existen plantillas registradas", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema al consultar las plantillas", ex);
            }

        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public PlantillaNotificacionDTO ConsultarPlantillaGUID(Guid id)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.Id == id).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese ID", ex);
            }
            
        }

        //GET: Servicio para consultar una plantilla notificacion por un título específico
        public PlantillaNotificacionDTO ConsultarPlantillaTitulo(string titulo)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.Titulo == titulo).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }catch(Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese título", ex);
            } 
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su nombre
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado)
        {
            try
            { 
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.TipoEstado.nombre == tituloTipoEstado).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla asociada a un tipo estado con ese titulo", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su ID
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoID(Guid id)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(et => et.etiquetaTipoEstado).ThenInclude(e => e.etiqueta).Where(p => p.TipoEstadoId == id).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionDTO>(data);
                return plantillaSearchDTO;
            }
            catch (InvalidOperationException ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese tipo estado", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Ocurrió un error durante la consulta", ex);
            }
        }

        //POST: Servicio para crear plantilla notificacion
        public Boolean RegistroPlantilla(PlantillaNotificacionDTOCreate plantilla)
        {
            try
            {
                var plantillaEntity = _mapper.Map<PlantillaNotificacion>(plantilla);
                plantillaEntity.Id = Guid.NewGuid();
                _plantillaContext.PlantillasNotificaciones.Add(plantillaEntity);
                _plantillaContext.DbContext.SaveChanges();

                //Comienza Prueba reemplazo de descripcion plantilla
                //var ticket = _plantillaContext.Tickets.Include(t => t.Estado)
                //                                      .Include(t => t.Tipo_Ticket)
                //                                      .Include(t => t.Prioridad)
                //                                      .Include(t => t.empleado)
                //                                      .Include(t => t.cliente)
                //                                      .Include(t => t.Departamento_Destino)
                //                                      .ThenInclude(d => d.Grupo).Where(t => t.Id == Guid.Parse("6F5ED7B9-1231-40FF-ACDB-F7291699A228")).Single();
                //var consulta = ConsultarPlantillaTipoEstadoTitulo("Rechazado");

                //var reemplazo = _notificacionService.ReemplazoEtiqueta(ticket, consulta);
                //var mail = _notificacionService.EnviarCorreo(consulta.Titulo, reemplazo, "alexguastaferro1@gmail.com");
                //Finaliza la prueba

                return true;
            }
            catch(DbUpdateException ex)
            {
                throw new ExceptionsControl("Ya existe una plantilla asociada a ese tipo estado o alguno de los campos de la plantilla está vacia", ex);
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar la plantilla", ex);
            }
        }

        //PUT: Servicio para modificar plantilla notificacion
        public Boolean ActualizarPlantilla(PlantillaNotificacionDTOCreate plantilla, Guid id)
        {
            try
            {
                var plantillaEntity = _mapper.Map<PlantillaNotificacion>(plantilla);
                plantillaEntity.Id = id;
                _plantillaContext.PlantillasNotificaciones.Update(plantillaEntity);
                _plantillaContext.DbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("Ya existe una plantilla asociada a ese tipo estado o alguno de los campos de la plantilla está vacia", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo actualizar la plantilla", ex);
            }
        }

        //DELETE: Servicio para eliminar plantilla notificacion
        public Boolean EliminarPlantilla(Guid id)
        {
            try
            {
                _plantillaContext.PlantillasNotificaciones.Remove( _plantillaContext.PlantillasNotificaciones.Find(id));
                _plantillaContext.DbContext.SaveChanges();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new ExceptionsControl("No existe ninguna plantilla con el id suministrado", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo eliminar la plantilla", ex);
            }
        
        }
    }
}
