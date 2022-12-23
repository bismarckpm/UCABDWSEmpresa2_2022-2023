using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
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
            CreateMap<Tipo_TicketDTOCreate, Tipo_TicketDTOUpdate>();


            CreateMap<Departamento, DepartamentoSearchDTO>();
            CreateMap<DepartamentoSearchDTO, Departamento>();

            CreateMap<Departamento, DepartamentoDto>();
            CreateMap<DepartamentoDto, Departamento>();


            CreateMap<Flujo_Aprobacion, Flujo_AprobacionDTOSearch>();
            CreateMap<Flujo_AprobacionDTOSearch, Flujo_Aprobacion>();

            /*CreateMap<Tipo_Cargo, Tipo_CargoDTOSearch>();
            CreateMap<Tipo_CargoDTOSearch, Tipo_Cargo>();

            CreateMap<Tipo_Cargo, TipoCargoDTO>();
            CreateMap<TipoCargoDTO, Tipo_Cargo>();*/

            CreateMap<Tipo_Ticket, Tipo_TicketDTOSearch>();
            CreateMap<Tipo_TicketDTOSearch, Tipo_Ticket>();

            CreateMap<Estado, EstadoDTOSearch>();
            CreateMap<Estado, EstadoDTOUpdate>();
            CreateMap<EstadoDTOUpdate, Estado>();

            CreateMap<Cargo, CargoDTOUpdate>();
            CreateMap<Cargo, CargoDto>();

            CreateMap<Departamento, DepartamentoSearchDTO>();

        }
    }
}
