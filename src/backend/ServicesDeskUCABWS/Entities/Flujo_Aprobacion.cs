using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDeskUCABWS.Entities
{
    public class Flujo_Aprobacion
    {
        /*public Flujo_Aprobacion(Guid idTicket, Guid idCargo, Tipo_Ticket Tipo_Ticket, Tipo_Cargo Tipo_Cargo)
        {
            this.IdTipo_cargo = idCargo;
            this.IdTicket=idTicket;
            this.Tipo_Ticket = Tipo_Ticket;
            this.Tipo_Cargo = Tipo_Cargo;

        }*/

        public Tipo_Cargo Tipo_Cargo { get; set; }

        public Tipo_Ticket Tipo_Ticket { get; set; }

        public int? OrdenAprobacion { get; set; }

        public int? Minimo_aprobado_nivel { get; set; }

        public int? Maximo_Rechazado_nivel { get; set; }

        public Guid IdTipo_cargo { get; set; }

        public Guid IdTicket { get; set; }

        public Flujo_Aprobacion(Guid idTipo_cargo, Guid idTicket, int? ordenAprobacion, int? minimo_aprobado_nivel, int? maximo_Rechazado_nivel)
        {
            OrdenAprobacion = ordenAprobacion;
            Minimo_aprobado_nivel = minimo_aprobado_nivel;
            Maximo_Rechazado_nivel = maximo_Rechazado_nivel;
            IdTipo_cargo = idTipo_cargo;
            IdTicket = idTicket;
        }

        public Flujo_Aprobacion()
        {

        }
    }
}
