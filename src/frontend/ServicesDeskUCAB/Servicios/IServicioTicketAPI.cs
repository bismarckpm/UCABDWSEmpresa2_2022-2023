using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.Servicios
{
    public interface IServicioTicketAPI
    {
        Task<Ticket> Obtener(string ticketId);

        Task<List<Ticket>> FamiliaTicket(string ticketId);

        Task<List<Bitacora_Ticket>> BitacoraTicket(string ticketId);

        Task<List<Ticket>> Lista(string departamentoId, string opcion);

        Task<JObject> Guardar(Ticket ticket);




        //Task<JObject> Editar();

        //Task<JObject> Merge(string ticketId, List<String> familiaId);

    }
}

