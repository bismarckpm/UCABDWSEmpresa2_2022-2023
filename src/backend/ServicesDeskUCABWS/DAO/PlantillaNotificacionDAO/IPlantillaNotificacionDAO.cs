using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.DAO.PlantillaNotificacionDAO
{
    public interface IPlantillaNotificacionDAO
    {
        public List<PlantillaNotificacionSearchDTO> ConsultaPlantillas();
        public PlantillaNotificacionSearchDTO ConsultarPlantillaGUID(Guid id);
        public List<PlantillaNotificacionSearchDTO> ConsultarPlantillaTitulo(string titulo);
        public Boolean RegistroPlantilla(PlantillaNotificacion plantilla);
    }
}
