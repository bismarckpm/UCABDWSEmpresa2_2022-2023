using System;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCAB.Servicios
{
	public interface IServicioTicketAPI
	{
        Task<TicketInfoCompleta> Obtener(string ticketId);

        Task<List<Ticket>> FamiliaTicket(string ticketId);

        Task<List<Bitacora_Ticket>> BitacoraTicket(string ticketId);

        Task<List<TicketInfoBasica>> Lista(string departamentoId, string opcion);

        Task<JObject> Guardar(TicketCrear Objeto);

        Task<JObject> GuardarReenviar(TicketReenviar Objeto);

        Task<JObject> GuardarMerge(TicketMerge Objeto);

        //Task<JObject> Editar();
    }
}

