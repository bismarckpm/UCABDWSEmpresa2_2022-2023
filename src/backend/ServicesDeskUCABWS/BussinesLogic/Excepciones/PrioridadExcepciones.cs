using System;

namespace ServicesDeskUCABWS.BussinesLogic.Excepciones
{
    public class PrioridadExcepciones : ApplicationException
    {
        public class PrioridadNoExisteException : ApplicationException
        {
            public PrioridadNoExisteException(string mensaje) : base(mensaje) { }
            public PrioridadNoExisteException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
        }
        public class PrioridadNombreLongitudException : ApplicationException
        {
            public PrioridadNombreLongitudException(string mensaje) : base(mensaje) { }
            public PrioridadNombreLongitudException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
        }
        public class PrioridadDescripcionLongitudException : ApplicationException
        {
            public PrioridadDescripcionLongitudException(string mensaje) : base(mensaje) { }
            public PrioridadDescripcionLongitudException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
        }
        public class PrioridadEstadoException : ApplicationException
        {
            public PrioridadEstadoException(string mensaje) : base(mensaje) { }
            public PrioridadEstadoException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
        }
    }
}
