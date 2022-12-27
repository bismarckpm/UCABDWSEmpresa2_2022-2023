using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
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

        public abstract List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo);

        public abstract bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla);


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

            contexto.Votos_Tickets.AddRange(ListaVotos);
        }
    }

    public class TipoTicket_FlujoNoAprobacion : Tipo_Ticket
    {
        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                return contexto.Empleados
                    .Where(s => s.Cargo.Departamento.id == ticket.Departamento_Destino.id)
                    .ToList(); 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket)
        {
            return new List<Cargo>();
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo)
        {
            return new List<Empleado>();
        }

        public override bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla)
        {
            try
            {
                ticket.CambiarEstado(ticket, "Pendiente", _dataContext);
                ticket.ActualizarBitacora(ticket, _dataContext);

                ticket.CambiarEstado(ticket, "Aprobado", _dataContext);
                ticket.ActualizarBitacora(ticket, _dataContext);
                ticket.EnviarNotificacion(ticket, "Aprobado", ListaEmpleados, _dataContext, notificacion, plantilla);

                ticket.CambiarEstado(ticket, "Siendo Procesado", _dataContext);
                ticket.ActualizarBitacora(ticket, _dataContext);
                ticket.EnviarNotificacion(ticket, "Siendo Procesado", ListaEmpleados, _dataContext, notificacion, plantilla);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public override string ObtenerTipoAprobacion()
        {
            return "Modelo_No_Aprobacion";
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
            try
            {
                ticket.nro_cargo_actual = 1;


                //Calcular Cargos
                var ListaCargos = CargosAsociados(contexto, ticket);

                //Agregar Votos
                AgregarVotos(contexto, EmpleadosVotantes(contexto, ListaCargos), ticket);


                return EmpleadosVotantes(contexto, ListaCargos);
            }
            catch (ExceptionsControl ex)
            {
                return null;
            }
        }

        public override List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket)
        {
            var Flujos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Cargo)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id)
                    .OrderBy(x => x.OrdenAprobacion).First();
            var ListaCargos = new List<Cargo>();
            ListaCargos.Add(Flujos.Cargo);
            return ListaCargos;
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo)
        {
            
            return contexto.Empleados.Where(x => x.Cargo.id == ListaCargo.First().id).ToList();
        }

        public override bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla)
        {
            try
            {
                ticket.CambiarEstado(ticket, "Pendiente", _dataContext);
                ticket.ActualizarBitacora(ticket, _dataContext);
                ticket.EnviarNotificacion(ticket, "Pendiente", ListaEmpleados, _dataContext, notificacion,plantilla);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ObtenerTipoAprobacion()
        {
            return "Modelo_Jerarquico";
        }

        public TipoTicket_FlujoAprobacionJerarquico(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo){ }

        public TipoTicket_FlujoAprobacionJerarquico(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado){ }
        
        public TipoTicket_FlujoAprobacionJerarquico() { }
    }

    public class TipoTicket_FlujoAprobacionParalelo : Tipo_Ticket
    {
        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                //Calcular Cargos
                var ListaCargos = CargosAsociados(contexto, ticket);

                //Agregar Votos
                AgregarVotos(contexto, EmpleadosVotantes(contexto, ListaCargos), ticket);


                return EmpleadosVotantes(contexto, ListaCargos);
            }
            catch (ExceptionsControl ex)
            {
                return null;
            }
        }

        public override List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket)
        {
            var Flujos = contexto.Flujos_Aprobaciones.Include(s => s.Cargo)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id).ToList();

            var Cargos = new List<Cargo>();
            foreach (var f in Flujos)
            {
                Cargos.Add(f.Cargo);
            }
            return Cargos;
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo)
        {
            var ListaEmpleado = new List<Empleado>();
            foreach (var c in ListaCargo)
            {
                ListaEmpleado.AddRange(contexto.Empleados.Where(x => x.Cargo.id == c.id));
            }
            return ListaEmpleado;
        }

        public override bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla)
        {
            try
            {
                ticket.CambiarEstado(ticket, "Pendiente", _dataContext);
                ticket.ActualizarBitacora(ticket, _dataContext);
                ticket.EnviarNotificacion(ticket, "Pendiente", ListaEmpleados, _dataContext, notificacion, plantilla);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ObtenerTipoAprobacion()
        {
            return "Modelo_Paralelo";
        }

        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo){ }

        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado){ }

        public TipoTicket_FlujoAprobacionParalelo() { }
    }

}

