using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesTipoTicket
{
    public class ValidacionesFlujoJerarquico : TipoTicketValidacionesGenerales
    {
        public ValidacionesFlujoJerarquico(IDataContext dataContext, Tipo_Ticket tipo_ticket) : base(dataContext, tipo_ticket) { }

        public void VerificarCargos()
        {
            foreach (var cargo in _tipo_ticket.ObtenerCargos())
            {
                if (!_tipo_ticket.HayMinimo_Aprobado_nivel(cargo) || !_tipo_ticket.HayMaximo_Aprobado_nivel(cargo) || !_tipo_ticket.HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NULL);
                }
                if (cargo.Minimo_aprobado_nivel <= 0 || cargo.Maximo_Rechazado_nivel <= 0)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MENOR_A_0_MAN_MRN_OS);
                }
            }
        }

        public void VerificarMinimoMaximoAprobado()
        {

            if (_tipo_ticket.HayMinimoAprobado() || _tipo_ticket.HayMaximo_Rechazado())
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NO_VALIDO);
            }
        }

        public void VerificarSecuenciaOrdenAprobacion()
        {
            int i = 1;
            foreach (var c in _tipo_ticket.ObtenerCargosOrdenados())
            {
                if (i != c.OrdenAprobacion)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_SEC_ORDEN_APROB);
                }
                i++;
            }
        }
    }
}
