using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceDeskUCAB.Models
{
    public class Estado
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ultima_edic { get; set; }
        public List<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public List<Ticket> ListaTickets { get; set; }
        public Depa Departamento { get; set; }

        public Estado(string nombre, string descripcion)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
            fecha_creacion = DateTime.UtcNow;
            fecha_ultima_edic = DateTime.UtcNow;
            //this.Estado_Padre = estado_Padre;
        }
    }
}
