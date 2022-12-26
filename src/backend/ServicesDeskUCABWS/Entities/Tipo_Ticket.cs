using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace ServicesDeskUCABWS.Entities
{
    public abstract class Tipo_Ticket
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(4)]
        public string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [MinLength(4)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public string tipo { get; set; }
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_ult_edic { get; set; }

        public DateTime? fecha_elim { get; set; }
        public List<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
        public List<DepartamentoTipo_Ticket> Departamentos { get; set; }
        public int? Minimo_Aprobado { get; set; }
        public int? Maximo_Rechazado { get; set; }

        public Tipo_Ticket(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = tipo;
            Minimo_Aprobado = MinimoAprobado;
            Maximo_Rechazado = MaximoRechazado;

            fecha_creacion = DateTime.UtcNow;
            fecha_ult_edic = DateTime.UtcNow;
            Flujo_Aprobacion = new List<Flujo_Aprobacion>();
            Departamentos = new List<DepartamentoTipo_Ticket>();
        }

        public Tipo_Ticket(string nombre, string descripcion, string tipo)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.tipo = tipo;

            fecha_creacion = DateTime.UtcNow;
            fecha_ult_edic = DateTime.UtcNow;
            Flujo_Aprobacion = new List<Flujo_Aprobacion>();
            Departamentos = new List<DepartamentoTipo_Ticket>();
        }

        public Tipo_Ticket()
        {

        }

        public abstract List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket);
    }

    public class TipoTicket_FlujoNoAprobacion : Tipo_Ticket
    {
        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                List<Empleado> ListaEmpleado = contexto.Empleados
                    .Where(s => s.Cargo.Departamento.id == ticket.Departamento_Destino.id)
                    .ToList();

                contexto.DbContext.SaveChanges();
                return ListaEmpleado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TipoTicket_FlujoNoAprobacion(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo)
        {

        }

        public TipoTicket_FlujoNoAprobacion(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre,descripcion,tipo,MinimoAprobado,MaximoRechazado)
        {
            
        }
        public TipoTicket_FlujoNoAprobacion() { }
    }

    public class TipoTicket_FlujoAprobacionJerarquico : Tipo_Ticket
    {
        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            string result = null;
            try
            {
                ticket.nro_cargo_actual = 1;

                var Flujos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Cargo)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id)
                    .OrderBy(x => x.OrdenAprobacion).First();

                var Cargos = Flujos.Cargo;


                var ListaEmpleado = contexto.Empleados.Where(x => x.Cargo.id == Cargos.id).ToList();


                var ListaVotos = ListaEmpleado.Select(x => new Votos_Ticket
                {
                    IdTicket = ticket.Id,
                    Ticket = ticket,
                    IdUsuario = x.Id,
                    Empleado = x,
                    voto = "Pendiente",
                    Turno = ticket.nro_cargo_actual
                });

                contexto.Votos_Tickets.AddRange(ListaVotos);

                return ListaEmpleado;
            }
            catch (ExceptionsControl ex)
            {
                return null;
            }
        }
        public TipoTicket_FlujoAprobacionJerarquico(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo)
        {

        }

        public TipoTicket_FlujoAprobacionJerarquico(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado)
        {

        }
        public TipoTicket_FlujoAprobacionJerarquico() { }
    }

    public class TipoTicket_FlujoAprobacionParalelo : Tipo_Ticket
    {
        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                var Flujos = contexto.Flujos_Aprobaciones.Include(s => s.Cargo)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id).ToList();

                var Cargos = new List<Cargo>();
                foreach (var f in Flujos)
                {
                    Cargos.Add(f.Cargo);
                }

                var ListaEmpleado = new List<Empleado>();
                foreach (var c in Cargos)
                {
                    ListaEmpleado.AddRange(contexto.Empleados.Where(x => x.Cargo.id == c.id));
                }

                var ListaVotos = ListaEmpleado.Select(x => new Votos_Ticket
                {
                    IdTicket = ticket.Id,
                    Ticket = ticket,
                    IdUsuario = x.Id,
                    Empleado = x,
                    voto = "Pendiente"
                });

                contexto.Votos_Tickets.AddRange(ListaVotos);

                return ListaEmpleado;
            }
            catch (ExceptionsControl ex)
            {
                return null;
            }
        }

        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo)
        {

        }

        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado)
        {

        }


        public TipoTicket_FlujoAprobacionParalelo() { }
    }

}

