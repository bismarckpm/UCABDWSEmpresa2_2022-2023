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
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public Modelo_aprobacion tipo { get; set; }
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_ult_edic { get; set; }
        public DateTime? fecha_elim { get; set; }
        public HashSet<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
        public HashSet<Departamento> Departamento { get; set; }
        public int? Minimo_Aprobado { get; set; }

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

