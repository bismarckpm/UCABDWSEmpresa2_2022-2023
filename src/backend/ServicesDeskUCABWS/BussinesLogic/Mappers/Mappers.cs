using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mappers
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            //Ejemplo
            //CreateMap<PlantillaNotificacion, PlantillaNotificacionSearchDTO>();
            //CreateMap<PlantillaNotificacionSearchDTO, PlantillaNotificacion>();

            CreateMap<Tipo_Ticket, Tipo_TicketDTOCreate>();
            CreateMap<Tipo_Ticket, Tipo_TicketDTOUpdate>();
            CreateMap<Tipo_TicketDTOUpdate, Tipo_TicketDTOCreate>();

        }
    }
}
