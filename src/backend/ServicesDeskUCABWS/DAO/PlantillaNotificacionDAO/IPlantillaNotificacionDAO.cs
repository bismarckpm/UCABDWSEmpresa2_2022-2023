using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Responses;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.DAO.PlantillaNotificacionDAO
{
    public interface IPlantillaNotificacionDAO
    {
        public List<PlantillaNotificacionSearchDTO> ConsultaPlantillas();
        public PlantillaNotificacionSearchDTO ConsultarPlantillaGUID(Guid id);
    }
}
