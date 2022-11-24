using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using System;
using System.Globalization;

namespace ServicesDeskUCABWS.BussinesLogic.Excepciones
{
    public class TicketException : ApplicationException
    {
        public TicketException(string mensaje) : base(mensaje) { }
        public TicketException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketTituloException : ApplicationException
    {
        public TicketTituloException(string mensaje) : base(mensaje){ }
        public TicketTituloException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna){ }
    }
    public class TicketDescripcionException : ApplicationException
    {
        public TicketDescripcionException(string mensaje) : base(mensaje) { }
        public TicketDescripcionException(string mensaje, Exception excepcionInterna):base(mensaje, excepcionInterna) { }
    }
    public class TicketFechaException : ApplicationException
    {
        public TicketFechaException(string mensaje) : base(mensaje) { }
        public TicketFechaException(string mensaje, Exception excepcionInterna):base(mensaje, excepcionInterna) { }
    }
    public class TicketDepartamentoException : ApplicationException
    {
        public TicketDepartamentoException(string mensaje) : base(mensaje) { }
        public TicketDepartamentoException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketEstadoException : ApplicationException
    {
        public TicketEstadoException(string mensaje) : base(mensaje) { }
        public TicketEstadoException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketPrioridadException : ApplicationException
    {
        public TicketPrioridadException(string mensaje) : base(mensaje) { }
        public TicketPrioridadException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketTipoException : ApplicationException
    {
        public TicketTipoException(string mensaje) : base(mensaje) { }
        public TicketTipoException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketVotosException : ApplicationException
    {
        public TicketVotosException(string mensaje) : base(mensaje) { }
        public TicketVotosException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketFamiliaException : ApplicationException
    {
        public TicketFamiliaException(string mensaje) : base(mensaje) { }
        public TicketFamiliaException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketEmisorException : ApplicationException
    {
        public TicketEmisorException(string mensaje) : base(mensaje) { }
        public TicketEmisorException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketPadreException : ApplicationException
    {
        public TicketPadreException(string mensaje) : base(mensaje) { }
        public TicketPadreException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
    public class TicketBitacoraException : ApplicationException
    {
        public TicketBitacoraException(string mensaje) : base(mensaje) { }
        public TicketBitacoraException(string mensaje, Exception excepcionInterna) : base(mensaje, excepcionInterna) { }
    }
}
