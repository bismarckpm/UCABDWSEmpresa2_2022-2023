using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using ServicesDeskUCABWS.Models;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class Flujo_AprobacionMapper : Profile
    {


        public Flujo_AprobacionMapper()
        {
            CreateMap<Flujo_Aprobacion, Flujo_AprobacionDTO>();
            CreateMap<Flujo_AprobacionDTO, Flujo_Aprobacion>();


        }

    }
}
