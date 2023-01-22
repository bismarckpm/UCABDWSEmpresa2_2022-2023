using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesTipoTicket
{
    public class TipoTicketValidacionesGenerales
    {
        protected readonly IDataContext _dataContext;
        protected readonly Tipo_Ticket _tipo_ticket;
        public TipoTicketValidacionesGenerales(IDataContext dataContext, Tipo_Ticket tipo_ticket)
        {
            _dataContext = dataContext;
            _tipo_ticket = tipo_ticket;
        }

        public void LongitudNombre()
        {
            if (_tipo_ticket.nombre.Length < 4 || _tipo_ticket.nombre.Length > 150)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.NOMBRE_FUERA_DE_RANGO);
            }
        }

        public void LongitudDescripcion()
        {
            if (_tipo_ticket.descripcion.Length < 4 || _tipo_ticket.descripcion.Length > 250)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.DESCRIPCION_FUERA_DE_RANGO);
            }
        }

        public void VerificarTipoFlujo()
        {
            if (!_dataContext.Modelos_Aprobacion.Select(x => x.discrimanador).Contains(_tipo_ticket.ObtenerTipoAprobacion()))
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_NO_VALIDO);
            }
        }

        public void VerificarDepartamento()
        {

            foreach (var dept in _tipo_ticket.Departamentos ?? new List<DepartamentoTipo_Ticket>())
            {
                if (_dataContext.Departamentos.Find(dept.DepartamentoId) == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.DEPARTAMENTO_NO_VALIDO);
                }
            }
        }

        public void VerificarSiCargosExisten()
        {
            foreach (var c in _tipo_ticket.ObtenerCargos())
            {
                if (_dataContext.Cargos.Find(c.IdCargo) == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_NO_VALIDO);
                }
            }
        }

        public void HayCargos()
        {
            if (_tipo_ticket.ObtenerCargos().Count() == 0)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_VACIO);
            }
        }
    }
}
