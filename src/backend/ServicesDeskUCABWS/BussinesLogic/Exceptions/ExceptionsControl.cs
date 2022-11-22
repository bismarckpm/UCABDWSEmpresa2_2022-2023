using System;

namespace ServicesDeskUCABWS.BussinesLogic.Exceptions
{
    public class ExceptionsControl : Exception
	{
		public string Mensaje { get; set; }
		public Exception Excepcion { get; set; }

		public ExceptionsControl(string _mensaje, Exception _excepcion)
		{
			Mensaje = _mensaje;
			Excepcion = _excepcion;
		}

		public ExceptionsControl(string _mensaje)
		{
			Mensaje = _mensaje;
		}

        public ExceptionsControl()
        {
        }
	}
}

