using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Exceptions;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //GET: Controlador para consultar todas las plantillas
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
    }
}
