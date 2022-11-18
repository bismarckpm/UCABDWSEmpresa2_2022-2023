using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class PlantillaNotificacionMapper:Profile
    {
        public PlantillaNotificacionMapper()
        {

            CreateMap<PlantillaNotificacion, PlantillaNotificacionDTO>();
            CreateMap<PlantillaNotificacionDTO, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacion, PlantillaNotificacionDTOCreate>();
            CreateMap<PlantillaNotificacionDTOCreate, PlantillaNotificacion>();

         

        }
    }
}
