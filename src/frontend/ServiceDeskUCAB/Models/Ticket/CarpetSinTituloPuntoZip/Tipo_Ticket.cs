using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServiceDeskUCAB.Models
{
    public class Tipo_Ticket
    {
        public Guid TipoTicketID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ModeloAprobacion ModeloAprobacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
        public int? MinimoAprobado { get; set; }
        public DateTime? FechaElim { get; set; }

        public ICollection<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
        public ICollection<Departamento> Departamento { get; set; }
        
    }

    public enum ModeloAprobacion
    {
        [EnumMember(Value = "MNA")]
        Modelo_No_Aprobacion,
        [EnumMember(Value = "MJ")]
        Modelo_Jerarquico,
        [EnumMember(Value = "MP")]
        Modelo_Paralelo,
    }

}

