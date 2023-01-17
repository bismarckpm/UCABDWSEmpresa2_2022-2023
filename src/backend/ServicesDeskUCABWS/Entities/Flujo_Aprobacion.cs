
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDeskUCABWS.Entities
{
    public class Flujo_Aprobacion
    {
        

        public Cargo Cargo { get; set; }

        public Tipo_Ticket Tipo_Ticket { get; set; }

        public int? OrdenAprobacion { get; set; }

        public int? Minimo_aprobado_nivel { get; set; }

        public int? Maximo_Rechazado_nivel { get; set; }

        public Guid IdCargo { get; set; }

        public Guid IdTicket { get; set; }

        public Flujo_Aprobacion(Guid idTipo_cargo, Guid idTicket, int? ordenAprobacion, int? minimo_aprobado_nivel, int? maximo_Rechazado_nivel)
        {
            OrdenAprobacion = ordenAprobacion;
            Minimo_aprobado_nivel = minimo_aprobado_nivel;
            Maximo_Rechazado_nivel = maximo_Rechazado_nivel;
            IdCargo = idTipo_cargo;
            IdTicket = idTicket;
        }

        public Flujo_Aprobacion()
        {

        }
    }
}
