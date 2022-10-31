using AutoMapper;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinessLogic.Mapper
{
    public class PlantillaNotificacionMapper:Profile
    {
        public PlantillaNotificacionMapper()
        {

            CreateMap<PlantillaNotificacion, PlantillaNotificacionSearchDTO>();
            CreateMap<PlantillaNotificacionSearchDTO, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacion, PlantillaNotificacionUpdateDTO>();
            CreateMap<PlantillaNotificacionUpdateDTO, PlantillaNotificacion>();

            CreateMap<PlantillaNotificacionSearchDTO, PlantillaNotificacionUpdateDTO>();
            CreateMap<PlantillaNotificacionUpdateDTO, PlantillaNotificacionSearchDTO>();

        }
    }
}
