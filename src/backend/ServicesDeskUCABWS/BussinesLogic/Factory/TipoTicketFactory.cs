using AutoMapper;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Factory
{
    public static class TipoTicketFactory
    {
        public static Tipo_Ticket ObtenerInstancia(string tipo_aprobacion)
        {
            switch (tipo_aprobacion)
            {
                case "Modelo_No_Aprobacion":
                    return new TipoTicket_FlujoNoAprobacion();
                case "Modelo_Paralelo":
                    return new TipoTicket_FlujoAprobacionParalelo();
                case "Modelo_Jerarquico":
                    return new TipoTicket_FlujoAprobacionJerarquico();
                default: 
                    throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_NO_VALIDO);
            }
        }

        /*public static Tipo_Ticket CambiarFlujoTipoTicket(Tipo_Ticket llegada, string tipo_aprobacion, IMapper mapper)
        {
            switch (tipo_aprobacion)
            {
                case "Modelo_No_Aprobacion":
                    return mapper.Map<TipoTicket_FlujoNoAprobacion>(llegada);
                case "Modelo_Paralelo":
                    return mapper.Map<TipoTicket_FlujoAprobacionParalelo>(llegada);
                case "Modelo_Jerarquico":
                    return mapper.Map<TipoTicket_FlujoAprobacionJerarquico>(llegada);
                default:
                    return llegada;
            }
        }*/
    }
}
