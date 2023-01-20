using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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

            fecha_creacion = DateTime.UtcNow;
            fecha_ult_edic = DateTime.UtcNow;
            Flujo_Aprobacion = new List<Flujo_Aprobacion>();
            Departamentos = new List<DepartamentoTipo_Ticket>();

        }

        public Tipo_Ticket()
        {

        }

        public abstract string ObtenerTipoAprobacion();
        public abstract List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket);

        public abstract List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket);

        public abstract List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo, Ticket ticket);

        public abstract Task<bool> CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion);

        public abstract string VerificarVotacion(Ticket ticket, IDataContext contexto, INotificacion notificacion);

        public abstract string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto);

        public abstract void ValidarTipoticketAgregar(IDataContext contexto);

        //public abstract void EnviarNotificaciones()

        public void AgregarVotos(IDataContext contexto, List<Empleado> ListaEmpleados, Ticket ticket)
         {
            var ListaVotos = ListaEmpleados.Select(x => new Votos_Ticket
            {
                IdTicket = ticket.Id,
                Ticket = ticket,
                IdUsuario = x.Id,
                Empleado = x,
                voto = "Pendiente",
                Turno = ticket.nro_cargo_actual
            });
            ticket.Votos_Ticket.AddRange(ListaVotos);
        }

        

        public abstract int ContarVotosAFavor(Ticket ticket, IDataContext contexto);
        public abstract int ContarVotosEnContra(Ticket ticket, IDataContext contexto);

        public void CambiarEstadoVotosPendiente(Ticket ticket, IDataContext contexto)
        {
            ticket.Votos_Ticket.Where(x=>x.voto == "Pendiente").ToList()
                .ForEach(x => x.voto = ticket.Estado.Estado_Padre.nombre);
        }

        public void LlenarDatos(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
            Minimo_Aprobado = MinimoAprobado;
            Maximo_Rechazado = MaximoRechazado;
            fecha_creacion = DateTime.UtcNow;
            fecha_ult_edic = DateTime.UtcNow;
            Flujo_Aprobacion = new List<Flujo_Aprobacion>();
            Departamentos = new List<DepartamentoTipo_Ticket>();
        }

        public List<Flujo_Aprobacion> ObtenerCargos()
        {
            return Flujo_Aprobacion.OrderBy(x => x.OrdenAprobacion).ToList();
        }
        public List<Flujo_Aprobacion> ObtenerCargosOrdenados()
        {
            return Flujo_Aprobacion.OrderBy(x => x.OrdenAprobacion).ToList();
        }
        public bool HayMinimoAprobado()
        {
            return Minimo_Aprobado != null;
        }
        public bool HayMaximo_Rechazado()
        {
            return Maximo_Rechazado != null;
        }
        public bool HayMinimo_Aprobado_nivel(Flujo_Aprobacion cargo)
        {
            return cargo.Minimo_aprobado_nivel != null;
        }
        public bool HayMaximo_Aprobado_nivel(Flujo_Aprobacion cargo)
        {
            return cargo.Maximo_Rechazado_nivel != null;
        }
        public bool HayOrdenAprobacion(Flujo_Aprobacion cargo)
        {
            return cargo.OrdenAprobacion != null;
        }

        //Validaciones
        public void LongitudNombre()
        {
            if (nombre.Length < 4 || nombre.Length > 150)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.NOMBRE_FUERA_DE_RANGO);
            }
        }

        public void LongitudDescripcion()
        {
            if (descripcion.Length < 4 || descripcion.Length > 250)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.DESCRIPCION_FUERA_DE_RANGO);
            }
        }

        public void VerificarDepartamento(IDataContext _dataContext)
        {
            foreach (var d in Departamentos.Select(x => x.DepartamentoId.ToString()).ToList() ?? new List<string>())
            {
                if (_dataContext.Departamentos.Find(Guid.Parse(d)) == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.DEPARTAMENTO_NO_VALIDO);
                }
            }
        }

        public void HayCargos()
        {
            if (ObtenerCargos().Count() == 0)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_VACIO);
            }
        }

        public void VerificarCargos(IDataContext contexto)
        {
            foreach (var cargos in ObtenerCargos())
            {
                if (contexto.Cargos.Find(cargos.IdCargo) == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_NO_VALIDO);
                }
            }
        }

        public abstract void VerificarFlujos();
        public abstract void VerificarMinimoMaximoAprobado();
    }

}

