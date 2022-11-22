using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;
using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;

namespace ServicesDeskUCABWS.BussinesLogic.Helpers
{
    public class TicketHelpers
    {

        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public TicketHelpers(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public TicketDTO crearNuevoTicket(TicketNuevoDTO solicitudTicket)
        {
            TicketDTO nuevoTicket = _mapper.Map<TicketDTO>(solicitudTicket);
            nuevoTicket.Id = new Guid();
            nuevoTicket.fecha_creacion = new DateTime();
            nuevoTicket.Emisor = _dataContext.Empleados.Where(empleado => empleado.Id == solicitudTicket.empleado_id).Single();
            nuevoTicket.Departamento_Destino = _dataContext.Departamentos.Where(departamento => departamento.Id == solicitudTicket.departamentoDestino_Id).Single();
            nuevoTicket.Estado = _dataContext.Estados.Where(x => x.Estado_Padre.nombre == "Pendiente" && x.Departamento.Id == nuevoTicket.Emisor.Cargo.Departamento.Id).FirstOrDefault();
            nuevoTicket.Prioridad = _dataContext.Prioridades.Where(prioridad => prioridad.Id == solicitudTicket.prioridad_id).Single();
            nuevoTicket.Tipo_Ticket = _dataContext.Tipos_Tickets.Where(tipoTicket => tipoTicket.Id == solicitudTicket.tipoTicket_id).Single();
            inicializarBitacora(nuevoTicket);
            return nuevoTicket;
        }
        public void inicializarBitacora(TicketDTO nuevoTicketDTO)
        {
            nuevoTicketDTO.Bitacora_Tickets = new HashSet<Bitacora_Ticket>
            {
                crearNuevaBitacora(nuevoTicketDTO)
            };
        }

        public Bitacora_Ticket crearNuevaBitacora(TicketDTO nuevoTicket)
        {
            return new Bitacora_Ticket()
            {
                Id = Guid.NewGuid(),
                Estado = nuevoTicket.Estado,
                Ticket = _mapper.Map<Ticket>(nuevoTicket),
                Fecha_Inicio = new DateTime()
            };
        }

        public void inicializarFamiliaTicket(TicketDTO nuevoTicket)
        {   //PARA LOS TICKETS HERMANOS
            nuevoTicket.Familia_Ticket = new Familia_Ticket()
            {
                Id = Guid.NewGuid(),
                Lista_Ticket = new List<Ticket>()
            };
        }

        public TicketInfoCompletaDTO rellenarTicketInfoCompleta(Guid id)
        {
            TicketDTO ticket = _mapper.Map<TicketDTO>(_dataContext.Tickets.Where(ticket => ticket.Id == id));
            Guid idPadre;
            if (ticket.Ticket_Padre.Id.Equals(Guid.Empty))
                idPadre = Guid.Empty;
            else
                idPadre = ticket.Ticket_Padre.Id;
            return new TicketInfoCompletaDTO
            {
                ticket_id = id,
                ticketPadre_id = idPadre,
                fecha_creacion = ticket.fecha_creacion,
                fecha_eliminacion = ticket.fecha_eliminacion,
                titulo = ticket.titulo,
                descripcion = ticket.descripcion,
                estado_nombre = ticket.Estado.nombre,
                tipoTicket_nombre = ticket.Tipo_Ticket.nombre,
                departamentoDestino_nombre = ticket.Departamento_Destino.nombre,
                prioridad_nombre = ticket.Prioridad.nombre,
                empleado_correo = ticket.Emisor.correo
            };
        }
    }
}
