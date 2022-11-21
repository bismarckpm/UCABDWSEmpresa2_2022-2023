using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.Servicios
{
    public interface IServicioTicketAPI
    {
        public Task<Models.Ticket> Obtener(string ticketId);

        public Task<List<Ticket>> FamiliaTicket(string ticketId);

        public Task<Bitacora_Ticket> BitacoraTicket(string ticketId);

        public Task<List<Models.Ticket>> Lista(string departamentoId, string opcion);

        public Task<bool> Guardar(Models.Ticket ticket);

        public Task<bool> Editar(Models.Ticket ticket);

        public Task<bool> GuardarFamilia(Familia_Ticket familiaTicket);

        public Task<bool> Reenviar(Ticket padre, Ticket hijo);

    }
}

