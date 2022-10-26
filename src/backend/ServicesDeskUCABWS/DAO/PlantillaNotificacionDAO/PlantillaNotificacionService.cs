using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Exceptions;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.DAO.PlantillaNotificacionDAO
{
    public class PlantillaNotificacionService : IPlantillaNotificacionDAO
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
            var data = _plantillaContext.PlantillasNotificaciones.Include(p => p.TipoEstado);
            var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionSearchDTO>>(data);
            return plantillaSearchDTO.ToList();
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico
        public PlantillaNotificacionSearchDTO ConsultarPlantillaGUID(Guid id)
        {
            try
            {
                var data = _plantillaContext.PlantillasNotificaciones.Include(p => p.TipoEstado).Where(p => p.Id == id).Single();
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
                var data = _plantillaContext.PlantillasNotificaciones.Include(p => p.TipoEstado).Where(p => p.Titulo == titulo);
                var plantillaSearchDTO = _mapper.Map<List<PlantillaNotificacionSearchDTO>>(data);
                return plantillaSearchDTO.ToList();
            }catch(Exception ex)
            {
                throw new ExceptionsControl("No existe la plantilla con ese título", ex);
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
    }
}
