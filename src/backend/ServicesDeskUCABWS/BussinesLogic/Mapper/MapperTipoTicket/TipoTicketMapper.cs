using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoTicket
{
    public class TipoTicketMapper
    {

       

        public static Tipo_Ticket CambiarFlujoTipoTicket(Tipo_Ticket llegada, string tipo,IMapper mapper)
        {
            if (tipo == "Modelo_Jerarquico")
            {
                return mapper.Map<TipoTicket_FlujoAprobacionJerarquico>(llegada);
            }
            if (tipo == "Modelo_Paralelo")
            {
                return mapper.Map<TipoTicket_FlujoAprobacionParalelo>(llegada);
            }
            if (tipo == "Modelo_No_Aprobacion")
            {
                return mapper.Map<TipoTicket_FlujoNoAprobacion>(llegada);
            }
            return llegada;
        }

        public static Tipo_TicketDTOCreate MapperTipoTicketToTipoTicketDTOCreate(Tipo_Ticket tipo_Ticket)
        {
            var DTO = new Tipo_TicketDTOCreate();
            DTO.nombre = tipo_Ticket.nombre;
            DTO.descripcion = tipo_Ticket.descripcion;
            DTO.tipo = tipo_Ticket.ObtenerTipoAprobacion();
            DTO.Maximo_Rechazado = tipo_Ticket.Maximo_Rechazado;
            DTO.Minimo_Aprobado = tipo_Ticket.Minimo_Aprobado;
            DTO.Departamento = tipo_Ticket.Departamentos.Select(x => x.DepartamentoId.ToString()).ToList();
            DTO.Flujo_Aprobacion = tipo_Ticket.Flujo_Aprobacion
                .Select(x => new FlujoAprobacionDTOCreate()
                {
                    IdCargo = x.IdCargo.ToString(),
                    Maximo_Rechazado_nivel = x.Maximo_Rechazado_nivel,
                    Minimo_aprobado_nivel = x.Minimo_aprobado_nivel,
                    OrdenAprobacion = x.OrdenAprobacion
                }).ToList();
            return DTO;
        }

        public static Tipo_TicketDTOUpdate MapperTipoTicketToTipoTicketDTOUpdate(Tipo_Ticket tipo_Ticket)
        {
            var DTO = new Tipo_TicketDTOUpdate();
            DTO.Id = tipo_Ticket.Id.ToString();
            DTO.nombre = tipo_Ticket.nombre;
            DTO.descripcion = tipo_Ticket.descripcion;
            DTO.tipo = tipo_Ticket.ObtenerTipoAprobacion();
            DTO.Maximo_Rechazado = tipo_Ticket.Maximo_Rechazado;
            DTO.Minimo_Aprobado = tipo_Ticket.Minimo_Aprobado;
            DTO.Departamento = tipo_Ticket.Departamentos.Select(x => x.DepartamentoId.ToString()).ToList();
            DTO.Flujo_Aprobacion = tipo_Ticket.Flujo_Aprobacion
                .Select(x => new FlujoAprobacionDTOCreate()
                {
                    IdCargo = x.IdCargo.ToString(),
                    Maximo_Rechazado_nivel = x.Maximo_Rechazado_nivel,
                    Minimo_aprobado_nivel = x.Minimo_aprobado_nivel,
                    OrdenAprobacion = x.OrdenAprobacion
                }).ToList();
            return DTO;
        }
    }
}
