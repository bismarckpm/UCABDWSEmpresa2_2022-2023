using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_Ticket;
using ServicesDeskUCABWS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO
{
    public interface ITipo_TicketDAO
    {

        public IEnumerable<Tipo_TicketDTO> ConsultarTipoTicket();
       // public Task<Tipo_Ticket?> ConsultarTipoTicketGUID(Guid id);

        public  Tipo_Ticket ConsultarTipoTicketGUID(Guid id);

        public Boolean EliminarTipoTicket(Guid id);

        //public Task<Tipo_Ticket?> ConsultarTipoTicketGUID(String nombre);
        // public IEnumerable<Tipo_Ticket> ConsultarNombreTipoTicket(String nombre);
        /*public  Task<Boolean> RegistroTipoTicket(Tipo_TicketDTO Tipo_TicketDTO);*/

    }
}
