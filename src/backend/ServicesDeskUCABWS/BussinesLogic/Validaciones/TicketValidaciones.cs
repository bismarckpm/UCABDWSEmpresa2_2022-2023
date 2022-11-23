using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Excepciones;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones
{
    public class TicketValidaciones
    {
        private readonly IDataContext _dataContext;
        public TicketValidaciones(IDataContext dataContext) 
        {
            _dataContext = dataContext;
        }
        public void nuevoTicketEsValido(TicketNuevoDTO nuevoTicket)
        {
            validarTitulo(nuevoTicket.titulo);
            validarDescripcion(nuevoTicket.descripcion);
            validarPrioridad(nuevoTicket.prioridad_id);
            validarTipoTicket(nuevoTicket.tipoTicket_id);
            validarDepartamento(nuevoTicket.departamentoDestino_Id);
            //validarEmisor(nuevoTicket.empleado_id);
        }
        public void validarTicket(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketException("El identificador del ticket no fué provisto");
            IQueryable<Ticket> tickets = _dataContext.Tickets.Where(tickets => tickets.Id == id);
            if (!tickets.Any())
                throw new TicketException("El ticket indicado no se encuentra registrado en la Base de Datos");
        }
        public void validarTitulo(string titulo)
        {
            if (titulo.Length < 3 || titulo.Length > 1000)
                throw new TicketTituloException("El formato del título no es válido");
        }
        public void validarDescripcion(string descripcion)
        {
            if (descripcion.Length < 3 || descripcion.Length > 4000)
                throw new TicketDescripcionException("El formato de la descripción no es válido");
        }
        public void validarFecha(DateTime fecha)
        {
            if (fecha.Equals(DateTime.Parse("")) || fecha.Equals(null))
                throw new TicketFechaException("Fecha no puede estar vacía o nula");
        }
        public void validarDepartamento(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketDepartamentoException("El identificador del departamento no fué provisto");
            IQueryable<Departamento> departamentos = _dataContext.Departamentos.Where(departamentos => departamentos.Id == id);
            if (!departamentos.Any())
                throw new TicketDepartamentoException("El departamento indicado no está registrado en la Base de Datos");
        }
        public void validarTicketEstado(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketEstadoException("El identificador del estado del ticket no fué provisto");
            IQueryable<Estado> estados = _dataContext.Estados.Where(estados => estados.Id == id);
            if (!estados.Any())
                throw new TicketEstadoException("El Estado indicado no está registrado en la Base de Datos");
        }
        public void validarPrioridad(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketPrioridadException("El identificador de la prioridad no fué provisto");
            IQueryable<Prioridad> prioridades = _dataContext.Prioridades.Where(prioridades => prioridades.Id == id);
            if (!prioridades.Any())
                throw new TicketPrioridadException("La prioridad indicada no se encuentra registrada en la base de datos");
        }
        public void validarTicketVotos(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketVotosException("El identificador del ticket voto no fué provisto");
            IQueryable<Votos_Ticket> votosTickets = _dataContext.Votos_Tickets.Where(votos => votos.Id == id);
            if (!votosTickets.Any())
                throw new TicketVotosException("Los votos indicados no se encuentran registrados en la base de datos");
        }
        public void validarTicketFamilia(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketFamiliaException("El identificador de la familia de tickets no fué provisto");
            IQueryable<Familia_Ticket> familiaTickets = _dataContext.Familia_Tickets.Where(familias => familias.Id == id);
            if (!familiaTickets.Any())
                throw new TicketFamiliaException("La familia de tickets indicada no se encuentra registrada en la Base de Datos");
        }
        public void validarEmisor(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketEmisorException("El identificador del ticket emisor no fué provisto");
            IQueryable<Empleado> emisor = _dataContext.Empleados.Where(empleado => empleado.Id == id);
            if (!emisor.Any())
                throw new TicketEmisorException("El emisor indicado no se encuentra registrado en la Base de Datos");
        }
        public void validarBitacora(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketBitacoraException("El identificador de la bitacora no fué provisto");
            IQueryable<Bitacora_Ticket> bitacora = _dataContext.Bitacora_Tickets.Where(bitacoras => bitacoras.Id == id);
            if (!bitacora.Any())
                throw new TicketBitacoraException("La bitacora indicada no se encuentra registrado en la Base de Datos");
        }
        public void validarTipoTicket(Guid? id)
        {
            if (id.Equals(Guid.Empty) || id.Equals(null))
                throw new TicketTipoException("El identificador del tipo de ticket no fué provisto");
            IQueryable<Tipo_Ticket> tipoTicket = _dataContext.Tipos_Tickets.Where(tipos => tipos.Id == id);
            if (!tipoTicket.Any())
                throw new TicketTipoException("El tipo de ticket indicado no se encuentra registrado en la Base de Datos");
        }

    }
}
