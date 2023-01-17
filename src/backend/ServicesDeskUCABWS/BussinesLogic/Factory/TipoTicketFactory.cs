using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
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
                    throw new ExceptionsControl("El tipo de aprobacion ingresado no es valido");
            }
        }
    }
}
