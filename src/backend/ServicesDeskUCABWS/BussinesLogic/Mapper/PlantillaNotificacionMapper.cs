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

            CreateMap<PlantillaNotificacion, PlantillaNotificacionUpdateDTO>();
            CreateMap<PlantillaNotificacionUpdateDTO, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacionDTO, PlantillaNotificacionUpdateDTO>();
            CreateMap<PlantillaNotificacionUpdateDTO, PlantillaNotificacionDTO>();

        }
    }
}
