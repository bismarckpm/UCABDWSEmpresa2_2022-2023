using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperPlantillaNotificacion;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO
{
    public class PlantillaNotificacionService : IPlantillaNotificacion
    {
        private readonly IDataContext _plantillaContext;
        private readonly IMapper _mapper;

        public PlantillaNotificacionService(IDataContext plantillaContext, IMapper mapper)
        {
            _plantillaContext = plantillaContext;
            _mapper = mapper;
        }

        //GET: Servicio para consultar todas las plantillas
        public List<PlantillaNotificacionDTO> ConsultaPlantillas()
        {
            try
            {
                var plantillaSearchDTO = PlantillaNotificacionMapper.MapperListaPlantillaEntityToPlantillaDto(
                    _plantillaContext.PlantillasNotificaciones.AsNoTracking()
                    .Include(p => p.TipoEstado)
                    .ThenInclude(et => et.etiquetaTipoEstado)
                    .ThenInclude(e => e.etiqueta)
                    .ToList()
                );

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
                var plantillaSearchDTO = PlantillaNotificacionMapper.MapperPlantillaEntityToPlantillaDto(
                    _plantillaContext.PlantillasNotificaciones.AsNoTracking()
                    .Include(p => p.TipoEstado)
                    .ThenInclude(et => et.etiquetaTipoEstado)
                    .ThenInclude(e => e.etiqueta)
                    .Where(p => p.Id == id)
                    .Single()
                );

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
                var plantillaSearchDTO = PlantillaNotificacionMapper.MapperPlantillaEntityToPlantillaDto(
                    _plantillaContext.PlantillasNotificaciones.AsNoTracking()
                    .Include(p => p.TipoEstado)
                    .ThenInclude(et => et.etiquetaTipoEstado)
                    .ThenInclude(e => e.etiqueta)
                    .Where(p => p.Titulo == titulo)
                    .Single()
                );
                return plantillaSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese título", ex);
            }
        }

        //GET: Servicio para consultar una plantilla notificacion por un tipo estado específico mediante su nombre
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado)
        {
            try
            {
                var plantillaSearchDTO = PlantillaNotificacionMapper.MapperPlantillaEntityToPlantillaDto(
                    _plantillaContext.PlantillasNotificaciones.AsNoTracking()
                    .Include(p => p.TipoEstado)
                    .ThenInclude(et => et.etiquetaTipoEstado)
                    .ThenInclude(e => e.etiqueta)
                    .Where(p => p.TipoEstado.nombre == tituloTipoEstado)
                    .Single()
                );
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
                var plantillaSearchDTO = PlantillaNotificacionMapper.MapperPlantillaEntityToPlantillaDto(
                    _plantillaContext.PlantillasNotificaciones.AsNoTracking()
                    .Include(p => p.TipoEstado)
                    .ThenInclude(et => et.etiquetaTipoEstado)
                    .ThenInclude(e => e.etiqueta)
                    .Where(p => p.TipoEstadoId == id)
                    .Single()
                );
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
                var plantillaEntity = PlantillaNotificacionMapper.MapperPlantillaCreateDtoToPlantillaEntity(plantilla);
                plantillaEntity.Id = Guid.NewGuid();
                _plantillaContext.PlantillasNotificaciones.Add(plantillaEntity);
                _plantillaContext.DbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new ExceptionsControl("Ya existe una plantilla asociada a ese tipo estado o alguno de los campos de la plantilla está vacia", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo registrar la plantilla", ex);
            }
        }

        //PUT: Servicio para modificar plantilla notificacion
        public Boolean ActualizarPlantilla(PlantillaNotificacionDTOCreate plantilla, Guid id)
        {
            try
            {
                var plantillaEntity = PlantillaNotificacionMapper.MapperPlantillaCreateDtoToPlantillaEntity(plantilla);
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
                var plantilla = ConsultarPlantillaGUID(id); 
                _plantillaContext.PlantillasNotificaciones.Remove(PlantillaNotificacionMapper.MapperPlantillaDtoToPlantillaEntity(plantilla));
                _plantillaContext.DbContext.SaveChanges();

                return true; 
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo eliminar la plantilla", ex);
            }

        }
    }
}
