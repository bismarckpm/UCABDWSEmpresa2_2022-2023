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

        private static List<FlujoAprobacionDTOCreate> ObtenerCargos(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            return tipo_TicketDTOCreate.Flujo_Aprobacion;
        }

        private static List<FlujoAprobacionDTOCreate> ObtenerCargosOrdenados(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
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

        public void HayCargos(Tipo_TicketDTOCreate tipoticket)
        {
            if (ObtenerCargos(tipoticket) == null)
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

        public bool HayMinimoAprobado(Tipo_TicketDTOCreate tipo)
        {
            return tipo.Minimo_Aprobado != null;
        }

        public bool HayMaximo_Rechazado(Tipo_TicketDTOCreate tipo)
        {
            return tipo.Maximo_Rechazado != null;
        }

        public bool HayMinimo_Aprobado_nivel(FlujoAprobacionDTOCreate cargo)
        {
            return cargo.Minimo_aprobado_nivel != null;
        }

        public bool HayMaximo_Aprobado_nivel(FlujoAprobacionDTOCreate cargo)
        {
            return cargo.Maximo_Rechazado_nivel != null;
        }

        public bool HayOrdenAprobacion(FlujoAprobacionDTOCreate cargo)
        {
            return cargo.OrdenAprobacion != null;
        }

        //Flujo Paralelo
        public void VerificarCargosFlujoParalelo(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            foreach (var cargo in ObtenerCargos(tipo_TicketDTOCreate))
            {
                if (HayMinimo_Aprobado_nivel(cargo) || HayMaximo_Aprobado_nivel(cargo) || HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NULL);
                }
            }
        }

        public void VerificarMinimoMaximoAprobadoFlujoParalelo(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            if (!HayMinimoAprobado(tipo_TicketDTOCreate) || !HayMaximo_Rechazado(tipo_TicketDTOCreate))
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NO_VALIDO);
            }
        }

        //Flujo Jerarquico
        public void VerificarCargosFlujoJerarquico(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            foreach (var cargo in ObtenerCargos(tipo_TicketDTOCreate))
            {
                if (!HayMinimo_Aprobado_nivel(cargo) || !HayMaximo_Aprobado_nivel(cargo) || !HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NULL);
                }
            }
        }

        public void VerificarMinimoMaximoAprobadoFlujoJerarquico(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            if (HayMinimoAprobado(tipo_TicketDTOCreate) || HayMaximo_Rechazado(tipo_TicketDTOCreate))
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NO_VALIDO);
            }
        }

        public void VerificarSecuenciaOrdenAprobacion(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            int i = 1;
            foreach (var c in ObtenerCargosOrdenados(tipo_TicketDTOCreate))
            {
                if (i != c.OrdenAprobacion)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_SEC_ORDEN_APROB);
                }
                i++;
            }
        }

        //Flujo No Aprobacion

    }
}
