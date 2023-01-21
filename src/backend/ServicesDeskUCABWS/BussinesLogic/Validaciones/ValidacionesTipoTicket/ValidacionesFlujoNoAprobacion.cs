using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesTipoTicket
{
    public class ValidacionesFlujoNoAprobacion : TipoTicketValidacionesGenerales
    {
        public ValidacionesFlujoNoAprobacion(IDataContext dataContext, Tipo_Ticket tipo_ticket) : base(dataContext, tipo_ticket) { }

        public void VerificarMinimoMaximoAprobado()
        {
            if (_tipo_ticket.HayMinimoAprobado() || _tipo_ticket.HayMaximo_Rechazado())
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_NO_VALIDO);
            }
        }

        public void VerificarCargos()
        {
            if (_tipo_ticket.Flujo_Aprobacion != null && _tipo_ticket.Flujo_Aprobacion.Count != 0)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_CARGO);
            }
        }
    }
}
