using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesTipoTicket
{
    public class ValidacionesActualizarTipoTicket : TipoTicketValidacionesGenerales
    {
        public ValidacionesActualizarTipoTicket(IDataContext dataContext, Tipo_Ticket tipo_ticket) : base(dataContext, tipo_ticket) { }

        public void VerificarTipoTicketExiste(Guid id)
        {
            if (BuscarTipoTicket(id) == null)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_TICKET_DESC);
            }
        }

        public Tipo_Ticket BuscarTipoTicket(Guid id)
        {
            return _dataContext.Tipos_Tickets.Find(id);
        }

        public void VerificarTicketsPendientes(Guid id)
        {
            if (TicketsPendientesConTipotickets(id) > 0)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_UPDATE_MODELO_APROBACION);
            }
        }

        public int TicketsPendientesConTipotickets(Guid id)
        {
            return _dataContext.Tickets.Include(x => x.Tipo_Ticket).Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                    .Where(x => x.Tipo_Ticket.Id == id &&
                    x.Estado.Estado_Padre.nombre == "Pendiente").Count();
        }
    }
}
