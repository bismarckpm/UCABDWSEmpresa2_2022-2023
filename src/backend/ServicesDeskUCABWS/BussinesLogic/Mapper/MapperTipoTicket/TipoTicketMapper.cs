using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Factory;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoTicket
{
    public class TipoTicketMapper
    {
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

        public static Tipo_Ticket MapperTipoTicketDTOCreatetoTipoTicket(Tipo_TicketDTOCreate DTO)
        {
            var tipo_ticket = TipoTicketFactory.ObtenerInstancia(DTO.tipo);
            tipo_ticket.Id = Guid.NewGuid();
            tipo_ticket.nombre = DTO.nombre;
            tipo_ticket.descripcion = DTO.descripcion;
            tipo_ticket.Maximo_Rechazado = DTO.Maximo_Rechazado;
            tipo_ticket.Minimo_Aprobado = DTO.Minimo_Aprobado;
            tipo_ticket.Departamentos = new List<DepartamentoTipo_Ticket>();
            foreach (var dept in DTO.Departamento ?? new List<string>())
            {
                tipo_ticket.Departamentos.Add(new DepartamentoTipo_Ticket()
                {
                    DepartamentoId = Guid.Parse(dept)
                });
            }
            tipo_ticket.Flujo_Aprobacion = new List<Flujo_Aprobacion>();
            foreach (var fa in DTO.Flujo_Aprobacion ?? new List<FlujoAprobacionDTOCreate>())
            {
                tipo_ticket.Flujo_Aprobacion.Add(new Flujo_Aprobacion()
                {
                    IdCargo = Guid.Parse(fa.IdCargo),
                    Maximo_Rechazado_nivel = fa.Maximo_Rechazado_nivel,
                    Minimo_aprobado_nivel = fa.Minimo_aprobado_nivel,
                    OrdenAprobacion = fa.OrdenAprobacion
                });
            }
            return tipo_ticket;
        }
        public static Tipo_Ticket MapperTipoTicketDTOUpdatetoTipoTicket(Tipo_TicketDTOUpdate DTO)
        {
            var tipo_ticket = TipoTicketFactory.ObtenerInstancia(DTO.tipo);
            tipo_ticket.Id = Guid.Parse(DTO.Id);
            tipo_ticket.nombre = DTO.nombre;
            tipo_ticket.descripcion = DTO.descripcion;
            tipo_ticket.Maximo_Rechazado = DTO.Maximo_Rechazado;
            tipo_ticket.Minimo_Aprobado = DTO.Minimo_Aprobado;
            tipo_ticket.Departamentos = new List<DepartamentoTipo_Ticket>();
            foreach (var dept in DTO.Departamento ?? new List<string>())
            {
                tipo_ticket.Departamentos.Add(new DepartamentoTipo_Ticket()
                {
                    DepartamentoId = Guid.Parse(dept)
                });
            }
            tipo_ticket.Flujo_Aprobacion = new List<Flujo_Aprobacion>();
            foreach (var fa in DTO.Flujo_Aprobacion ?? new List<FlujoAprobacionDTOCreate>())
            {
                tipo_ticket.Flujo_Aprobacion.Add(new Flujo_Aprobacion()
                {
                    IdCargo = Guid.Parse(fa.IdCargo),
                    Maximo_Rechazado_nivel = fa.Maximo_Rechazado_nivel,
                    Minimo_aprobado_nivel = fa.Minimo_aprobado_nivel,
                    OrdenAprobacion = fa.OrdenAprobacion,

                });
            }
            return tipo_ticket;
        }
    }
}
