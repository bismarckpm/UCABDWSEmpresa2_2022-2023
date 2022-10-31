using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using ServicesDeskUCABWS.Models;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
{
    public class Tipo_TicketMapper : Profile
    {

        public Tipo_TicketMapper()
        {
            CreateMap<Tipo_Ticket, Tipo_TicketDTO>();
            CreateMap<Tipo_TicketDTO, Tipo_Ticket>();


        }
    }
}
