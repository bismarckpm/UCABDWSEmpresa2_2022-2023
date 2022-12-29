using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones
{
    public class TipoTicketValidaciones
    {
        private readonly IDataContext _dataContext;
        public TipoTicketValidaciones(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private static List<Flujo_Aprobacion> ObtenerCargos(Tipo_Ticket tipo_TicketDTOCreate)
        {
            return tipo_TicketDTOCreate.Flujo_Aprobacion;
        }

        private static List<Flujo_Aprobacion> ObtenerCargosOrdenados(Tipo_Ticket tipo_TicketDTOCreate)
        {
            return tipo_TicketDTOCreate.Flujo_Aprobacion.OrderBy(x => x.OrdenAprobacion).ToList();
        }

        public void LongitudNombre(string nombre)
        {
            if (nombre.Length < 4 || nombre.Length > 150)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.NOMBRE_FUERA_DE_RANGO);
            }
        }

        public void LongitudDescripcion(string descripcion)
        {
            if (descripcion.Length < 4 || descripcion.Length > 250)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.DESCRIPCION_FUERA_DE_RANGO);
            }
        }

        public void VerificarTipoFlujo(string tipo)
        {
            if (!_dataContext.Modelos_Aprobacion.Select(x => x.discrimanador).Contains(tipo))
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_NO_VALIDO);
            }
        }

        public void VerificarDepartamento(List<string> departamentos)
        {
            foreach (var d in departamentos ?? new List<string>())
            {
                if (_dataContext.Departamentos.Find(Guid.Parse(d)) == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.DEPARTAMENTO_NO_VALIDO);
                }
            }
        }

        public void HayCargos(Tipo_Ticket tipoticket)
        {
            if (ObtenerCargos(tipoticket).Count() == 0)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_VACIO);
            }
        }

        public void VerificarCargos(IEnumerable<string> Cargos)
        {
            foreach (var c in Cargos)
            {
                if (_dataContext.Cargos.Find(Guid.Parse(c)) == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_NO_VALIDO);
                }
            }
        }

        public bool HayMinimoAprobado(Tipo_Ticket tipo)
        {
            return tipo.Minimo_Aprobado != null;
        }

        public bool HayMaximo_Rechazado(Tipo_Ticket tipo)
        {
            return tipo.Maximo_Rechazado != null;
        }

        public bool HayMinimo_Aprobado_nivel(Flujo_Aprobacion cargo)
        {
            return cargo.Minimo_aprobado_nivel != null;
        }

        public bool HayMaximo_Aprobado_nivel(Flujo_Aprobacion cargo)
        {
            return cargo.Maximo_Rechazado_nivel != null;
        }

        public bool HayOrdenAprobacion(Flujo_Aprobacion cargo)
        {
            return cargo.OrdenAprobacion != null;
        }

        //Flujo Paralelo
        public void VerificarCargosFlujoParalelo(Tipo_Ticket tipo_ticket)
        {
            foreach (var cargo in ObtenerCargos(tipo_ticket))
            {
                if (HayMinimo_Aprobado_nivel(cargo) || HayMaximo_Aprobado_nivel(cargo) || HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NULL);
                }
            }
        }

        public void VerificarMinimoMaximoAprobadoFlujoParalelo(Tipo_Ticket tipo_ticket)
        {
            if (!HayMinimoAprobado(tipo_ticket) || !HayMaximo_Rechazado(tipo_ticket))
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NO_VALIDO);
            }
        }

        //Flujo Jerarquico
        public void VerificarCargosFlujoJerarquico(Tipo_Ticket tipo_ticket)
        {
            foreach (var cargo in ObtenerCargos(tipo_ticket))
            {
                if (!HayMinimo_Aprobado_nivel(cargo) || !HayMaximo_Aprobado_nivel(cargo) || !HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NULL);
                }
            }
        }

        public void VerificarMinimoMaximoAprobadoFlujoJerarquico(Tipo_Ticket tipo_ticket)
        {
            if (HayMinimoAprobado(tipo_ticket) || HayMaximo_Rechazado(tipo_ticket))
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NO_VALIDO);
            }
        }

        public void VerificarSecuenciaOrdenAprobacion(Tipo_Ticket tipo_ticket)
        {
            int i = 1;
            foreach (var c in ObtenerCargosOrdenados(tipo_ticket))
            {
                if (i != c.OrdenAprobacion)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_SEC_ORDEN_APROB);
                }
                i++;
            }
        }

        //Flujo No Aprobacion
        public void VerificarMinimoMaximoAprobadoFlujoNoAprobacion(Tipo_Ticket tipo_ticket)
        {
            if (HayMinimoAprobado(tipo_ticket) || HayMaximo_Rechazado(tipo_ticket))
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_NO_VALIDO);
            }
        }

        public void VerificarCargosFlujoNoAprobacion(Tipo_Ticket tipo_ticket)
        {
            if (tipo_ticket.Flujo_Aprobacion != null)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_CARGO);
            }
        }
    }
}
