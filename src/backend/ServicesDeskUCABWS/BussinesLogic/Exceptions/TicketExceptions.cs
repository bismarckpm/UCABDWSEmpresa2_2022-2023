
/*
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.Exceptions
{
    public class TicketExceptions : Exception
    {
        private static TicketExceptions instancia { get; set; }
        private TicketExceptions(){}
        public static TicketExceptions getInstance()
        {
            if (instancia == null)
                instancia = new TicketExceptions();
            return instancia;
        }
        public void nuevoTicketEsValido(TicketNuevoDTO nuevoTicket)
        {
            //if (nuevoTicket.Id == null)
            //    throw new Exception("El ID del ticket no es válido");
            if (nuevoTicket.titulo.Length == 0)
                throw new Exception("El titulo del ticket no puede estar vacío");
            if (nuevoTicket.descripcion.Length < 5)
                throw new Exception("La descripción del ticket no es lo suficientemente detallado (longitud de la cadena menor a 5 caracteres)");
            //if (nuevoTicket.fecha_creacion == null)
            //    throw new Exception("La fecha de creación no fué proporcionada");
            if (nuevoTicket.estado_nombre == null)
                throw new Exception("El estado del ticket no fué proporcionado");
            if (nuevoTicket.prioridad_nombre == null)
                throw new Exception("La prioridad del ticket no fué establecido");
            if (nuevoTicket.tipoTicket_nombre == null)
                throw new Exception("El tipo del ticket no fué establecido");
            if (nuevoTicket.departamentoDestino_nombre == null)
                throw new Exception("El departamento destino del ticket no fue establecido");
        }
    }
}
*/