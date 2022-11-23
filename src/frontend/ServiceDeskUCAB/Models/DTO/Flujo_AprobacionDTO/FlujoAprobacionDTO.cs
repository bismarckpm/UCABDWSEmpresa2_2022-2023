using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models.DTO.Flujo_AprobacionDTO
{
    public class FlujoAprobacionDTO
    {


        /*public FlujoAprobacionDTO(Guid Id, string nombre, string tipo, Guid IdCargo, string nombreCargo)
        {
            IdTipoTicket = Id;
            nombreTipoTicket = nombre;
            this.tipo = tipo;
            /*IdTipoCargo = IdCargo;
            tipo_cargo = nombreCargo;*/
        //}*/

        public Guid IdTipoTicket { get; set; }

        public string nombreTipoTicket { get; set; } = string.Empty;

        public string tipo { get; set; }

        public Guid IdTipoCargo { get; set; }


        public string tipo_cargo { get; set; }

        public Cargo cargo { get; set; }
        //public List<Tipo_Cargo> Cargos { get; set;}

        /* public static explicit operator FlujoAprobacionDTO(List<Tipo_Ticket> v)
         {

         }*/
    }
}
