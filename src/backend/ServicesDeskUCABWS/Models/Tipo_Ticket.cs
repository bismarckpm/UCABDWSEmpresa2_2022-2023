using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCABWS.Models
{
    public class Tipo_Ticket
    {
        [Key]
        private Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        private string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        private string descripcion { get; set; } = string.Empty;
        [Required]
        private Modelo_aprobacion tipo { get; set; }
        [Required]
        private DateTime fecha_creacion { get; set; }
        [Required]
        private DateTime fecha_ult_edic { get; set; }
        [Required]
        private DateTime fecha_elim { get; set; }
        private HashSet<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
        private HashSet<Departamento> Departamento { get; set; }
        private int? Minimo_Aprobado { get; set; }

    }
    public enum Modelo_aprobacion
    {
        [EnumMember(Value = "MNA")]
        Modelo_No_Aprobacion,
        [EnumMember(Value = "MJ")]
        Modelo_Jerarquico,
        [EnumMember(Value = "MP")]
        Modelo_Paralelo,
    }
}

