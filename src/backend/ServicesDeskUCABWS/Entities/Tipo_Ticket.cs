using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
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

        public abstract List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo, Ticket ticket);

        public abstract bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla);

        public abstract string VerificarVotacion(Guid idTicket, IDataContext contexto);

        public abstract string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto);

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

        public Ticket ConsultarDatosTicket(Guid idTicket, IDataContext contexto)
        {
            return contexto.Tickets
                    .AsNoTracking()
                    .Include(x => x.Departamento_Destino).Include(x => x.Tipo_Ticket)
                    .Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                    .Include(x => x.Emisor).ThenInclude(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Where(x => x.Id == idTicket).FirstOrDefault();
        }

        public abstract int ContarVotosAFavor(Guid idTicket, IDataContext contexto);
        public abstract int ContarVotosEnContra(Guid idTicket, IDataContext contexto);

        public void CambiarEstadoVotosPendiente(Ticket ticket, IDataContext contexto)
        {
            contexto.Votos_Tickets
                .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                .ToList().ForEach(x => x.voto = ticket.Estado.Estado_Padre.nombre);
        }
    }

}

