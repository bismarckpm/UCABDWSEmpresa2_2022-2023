using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesTipoTicket
{
    public class ValidacionesFlujoParalelo : TipoTicketValidacionesGenerales
    {
        public ValidacionesFlujoParalelo(IDataContext dataContext, Tipo_Ticket tipo_ticket) : base(dataContext, tipo_ticket){ }

        public void VerificarCargos()
        {
            foreach (var cargo in _tipo_ticket.ObtenerCargos())
            {
                if (_tipo_ticket.HayMinimo_Aprobado_nivel(cargo) || _tipo_ticket.HayMaximo_Aprobado_nivel(cargo) || _tipo_ticket.HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NULL);
                }

            }
        }

        public void VerificarMinimoMaximoAprobado()
        {
            if (!_tipo_ticket.HayMinimoAprobado() || !_tipo_ticket.HayMaximo_Rechazado())
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NO_VALIDO);
            }
            if (_tipo_ticket.Minimo_Aprobado <= 0 || _tipo_ticket.Maximo_Rechazado <= 0)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MENOR_A_0_MA_MR);
            }
        }
    }
}
