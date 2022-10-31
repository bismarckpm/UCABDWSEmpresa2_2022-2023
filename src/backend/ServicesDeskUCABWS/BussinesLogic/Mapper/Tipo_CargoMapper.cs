using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using ServicesDeskUCABWS.Models;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class Tipo_CargoMapper : Profile
    {

        public Tipo_CargoMapper()
        {
            CreateMap<Tipo_Cargo, Tipo_CargoDTO>();
            CreateMap<Tipo_CargoDTO, Tipo_Cargo>();


        }
    }
}
