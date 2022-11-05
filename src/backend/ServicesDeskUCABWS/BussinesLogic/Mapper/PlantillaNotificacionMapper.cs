using AutoMapper;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinessLogic.Mapper
{
    public class PlantillaNotificacionMapper:Profile
    {
        public PlantillaNotificacionMapper()
        {

            CreateMap<PlantillaNotificacion, PlantillaNotificacionDTO>();
            CreateMap<PlantillaNotificacionDTO, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacion, PlantillaNotificacionDTOCreate>();
            CreateMap<PlantillaNotificacionDTOCreate, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacionDTO, PlantillaNotificacionUpdateDTO>();
            CreateMap<PlantillaNotificacionUpdateDTO, PlantillaNotificacionDTO>();

        }
    }
}
