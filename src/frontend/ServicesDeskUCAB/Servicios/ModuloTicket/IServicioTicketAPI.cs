using System;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCAB.Servicios
{
	public interface IServicioTicketAPI
	{
        Task<TicketCompletoDTO> Obtener(string ticketId);

        Task<List<Ticket>> FamiliaTicket(string ticketId);

        Task<List<BitacoraDTO>> BitacoraTicket(string ticketId);

        Task<List<TicketBasicoDTO>> Lista(string departamentoId, string opcion);

        Task<JObject> Guardar(TicketDTO Objeto);

        Task<JObject> GuardarReenviar(TicketReenviar Objeto);

        Task<JObject> GuardarMerge(FamiliaMergeDTO Objeto);

        //Task<JObject> Editar();
    }
}

