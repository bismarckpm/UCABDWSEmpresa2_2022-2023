using AutoMapper;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Models;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Mapper
{
    public class PlantillaNotificacionMapper:Profile
    {
        public PlantillaNotificacionMapper()
        {

            CreateMap<PlantillaNotificacion, PlantillaNotificacionSearchDTO>();
            CreateMap<PlantillaNotificacionSearchDTO, PlantillaNotificacion>();

        }
    }
}
