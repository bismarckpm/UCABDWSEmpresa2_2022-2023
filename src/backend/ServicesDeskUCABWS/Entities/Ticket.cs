using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ServicesDeskUCABWS.BussinesLogic;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required,MaxLength(1000),MinLength(3)]
        public string titulo { get; set; } = string.Empty;

        [Required, MaxLength(4000),MinLength(3)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_creacion { get; set; }

        public DateTime? fecha_eliminacion { get; set; }

        public Estado Estado { get; set; }

        [Required]
        public Prioridad Prioridad{ get; set; }

        [Required]
        public Departamento Departamento_Destino { get; set; }

        [Required]
        public Tipo_Ticket Tipo_Ticket { get; set; }

        public HashSet<Votos_Ticket>? Votos_Ticket { get; set; }

        public Familia_Ticket? Familia_Ticket { get; set; }

        public Ticket? Ticket_Padre { get; set; }
        public Empleado Emisor { get; set; }
        public Guid EmisorId {get; set;}
        public Empleado? Responsable {get; set;}
        public Guid? ResponsableId {get; set;}
        
        public Ticket() { }

        public Ticket(string titulo, string descripcion)
        {
            Id = Guid.NewGuid();
            this.titulo = titulo;
            this.descripcion = descripcion;
            //this.Departamento_Destino = Departamento_Destino;
            fecha_creacion = DateTime.UtcNow;
            //this.Estado=
        }
        public Ticket(Guid Id, string titulo, string descripcion, DateTime fecha_creacion, DateTime fecha_eliminacion, Departamento Departamento_Destino)
        {
            Id = Guid.NewGuid();
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.Departamento_Destino = Departamento_Destino;
            this.fecha_creacion = DateTime.UtcNow;
        }

        public HashSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }

        public int? nro_cargo_actual { get; set; }

        

        public bool CambiarEstado( string Estado, IDataContext _dataContext)
        {
            try
            {
                this.Estado = _dataContext.Estados
                    .Include(x => x.Estado_Padre)
                    .Include(x => x.Departamento)
                    .Where(s => s.Estado_Padre.nombre == Estado && s.Departamento.id == this.Emisor.Cargo.Departamento.id)
                    .FirstOrDefault();

                ActualizarBitacora( _dataContext);
            }
            catch (ExceptionsControl ex)
            {
                return false;
            }
            return true;
        }

        public bool CambiarEstadoUsuario(string Estado, IDataContext _dataContext)
        {
            try
            {
                this.Estado = _dataContext.Estados
                    .Include(x => x.Estado_Padre)
                    .Include(x => x.Departamento)
                    .Where(s => s.Estado_Padre.nombre == Estado && s.Departamento.id == this.Departamento_Destino.id)
                    .FirstOrDefault();

                ActualizarBitacora(_dataContext);
            }
            catch (ExceptionsControl ex)
            {
                return false;
            }
            return true;
        }


        public Bitacora_Ticket crearNuevaBitacora(Ticket ticket)
        {
            Bitacora_Ticket nuevaBitacora = new Bitacora_Ticket()
            {
                Id = Guid.NewGuid(),
                Estado = ticket.Estado,
                Ticket = ticket,
                Fecha_Inicio = DateTime.Today,
                Fecha_Fin = null
            };
            return nuevaBitacora;
        }

        internal void ActualizarBitacora( IDataContext _dataContext)
        {
            Bitacora_Ticket nuevaBitacora = crearNuevaBitacora(this);
            if (this.Bitacora_Tickets.Count != 0)
            {
                this.Bitacora_Tickets.Last().Fecha_Fin = DateTime.UtcNow;
            }
            this.Bitacora_Tickets.Add(nuevaBitacora);
            _dataContext.Bitacora_Tickets.Add(nuevaBitacora);
            _dataContext.Tickets.Update(this);
        }
    }
}



