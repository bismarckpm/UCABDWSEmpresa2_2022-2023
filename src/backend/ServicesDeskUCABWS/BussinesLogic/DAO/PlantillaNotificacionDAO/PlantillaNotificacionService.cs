using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO
{
    public class PlantillaNotificacionService : IPlantillaNotificacion
    {
        private readonly DataContext _plantillaContext;
        private readonly IMapper _mapper;

        public PlantillaNotificacionService(DataContext plantillaContext, IMapper mapper)
        {
            _plantillaContext = plantillaContext;
            _mapper = mapper;
        }

        //GET: Servicio para consultar todas las plantillas
        public List<PlantillaNotificacionSearchDTO> ConsultaPlantillas()
        {
            var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(e => e.Etiqueta);
            var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionSearchDTO>>(data);
            return plantillaSearchDTO.ToList();
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public PlantillaNotificacionSearchDTO ConsultarPlantillaGUID(Guid id)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(e => e.Etiqueta).Where(p => p.Id == id).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionSearchDTO>(data);
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese ID", ex);
            }
            
        }

        //GET: Servicio para consultar una plantilla notificacion por un título específico
        public List<PlantillaNotificacionSearchDTO> ConsultarPlantillaTitulo(string titulo)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(e => e.Etiqueta).Where(p => p.Titulo == titulo);
                var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionSearchDTO>>(data);
                return plantillaSearchDTO.ToList();
            }catch(Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese título", ex);
            } 
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su nombre
        public List<PlantillaNotificacionSearchDTO> ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado)
        {
            try
            {
                
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(e => e.Etiqueta).Where(p => p.TipoEstado.nombre == tituloTipoEstado);
                var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionSearchDTO>>(data);
                return plantillaSearchDTO.ToList();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese tipo estado", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su ID
        public PlantillaNotificacionSearchDTO ConsultarPlantillaTipoEstadoID(Guid id)
        {
            try
            {
                
                var data = _plantillaContext.PlantillasNotificaciones.AsNoTracking().Include(p => p.TipoEstado).ThenInclude(e => e.Etiqueta).Where(p => p.TipoEstado.Id == id).Single();
                var plantillaSearchDTO = _mapper.Map<PlantillaNotificacionSearchDTO>(data);
                return plantillaSearchDTO;
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese tipo estado", ex);
            }
        }

        //POST: Servicio para crear plantilla notificacion
        public Boolean RegistroPlantilla(PlantillaNotificacion plantilla)
        {
            try
            {
                _plantillaContext.PlantillasNotificaciones.Add(plantilla);
                _plantillaContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar la plantilla", ex);
            }
        }

        //PUT: Servicio para modificar plantilla notificacion
        public Boolean ActualizarPlantilla(PlantillaNotificacionUpdateDTO plantilla)
        {
            try
            {
                var plantillaUpdate = _mapper.Map<PlantillaNotificacion>(plantilla);
                _plantillaContext.PlantillasNotificaciones.Update(plantillaUpdate);
                _plantillaContext.SaveChanges();
                return true;
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
                var plantillaExist = ConsultarPlantillaGUID(id);
                var plantilla = _mapper.Map<PlantillaNotificacion>(plantillaExist);
                //var plantilla = _plantillaContext.PlantillasNotificaciones.Include(p => p.TipoEstado).Where(p => p.Id == id).Single();
                _plantillaContext.PlantillasNotificaciones.Remove(plantilla);
                _plantillaContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new ExceptionsControl("No se pudo eliminar la plantilla", ex);
            }
        
        }
    }
}
