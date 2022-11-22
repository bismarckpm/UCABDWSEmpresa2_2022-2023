using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.Servicios
{
    public interface IServicioTicketAPI
    {
        Task<Ticket> Obtener(string ticketId);

        Task<List<Ticket>> FamiliaTicket(string ticketId);

        Task<Bitacora_Ticket> BitacoraTicket(string ticketId);

        Task<List<Ticket>> Lista(string departamentoId, string opcion);

        Task<bool> Guardar(Ticket ticket);

        Task<bool> Editar(Ticket ticket);

        Task<bool> GuardarFamilia(Familia_Ticket familiaTicket);

        Task<bool> Reenviar(Ticket padre, Ticket hijo);

    }
}

