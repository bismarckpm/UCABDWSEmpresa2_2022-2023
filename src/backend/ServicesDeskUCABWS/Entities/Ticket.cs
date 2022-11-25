using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;

namespace ServicesDeskUCABWS.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(1000)]
        [MinLength(3)]
        public string titulo { get; set; } = string.Empty;
        [Required]
        [MaxLength(4000)]
        [MinLength(3)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_eliminacion { get; set; }


        public Estado Estado { get; set; }
        [Required]
        public Prioridad Prioridad { get; set; }
        [Required]
        public Tipo_Ticket Tipo_Ticket { get; set; }

        public HashSet<Votos_Ticket> Votos_Ticket { get; set; }
        [Required]
        public Departamento Departamento_Destino { get; set; }
        public Familia_Ticket Familia_Ticket { get; set; }
        public Ticket Ticket_Padre { get; set; }
        public Empleado Emisor { get; set; }
        public HashSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public int? nro_cargo_actual { get; set; }


        public Ticket(Guid Id, string titulo, string descripcion, DateTime fecha_creacion, DateTime fecha_eliminacion, Departamento Departamento_Destino)
        {
            Id = Guid.NewGuid();
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.Departamento_Destino = Departamento_Destino;
            this.fecha_creacion = DateTime.UtcNow;
            //this.Estado=

        }



        public Ticket(string titulo, string descripcion)
        {
            Id = Guid.NewGuid();
            this.titulo = titulo;
            this.descripcion = descripcion;
            //this.Departamento_Destino = Departamento_Destino;
            fecha_creacion = DateTime.UtcNow;
            //this.Estado=

        }

        public Ticket()
        {
        }
    }
}



