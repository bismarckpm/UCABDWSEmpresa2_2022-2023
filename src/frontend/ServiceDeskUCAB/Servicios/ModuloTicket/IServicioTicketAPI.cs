using System;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDeskUCAB.Models.DTO.TicketDTO;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
	public interface IServicioTicketAPI
	{
        Task<TicketCompletoDTO> Obtener(string ticketId);

        Task<List<Ticket>> FamiliaTicket(string ticketId);

        Task<List<BitacoraDTO>> BitacoraTicket(string ticketId);

        Task<List<TicketBasicoDTO>> Lista(string departamentoId, string opcion);

        Task<JObject> Cancelar(string ticketId);

        Task<JObject> Guardar(TicketDTO Objeto);

        Task<JObject> GuardarReenviar(TicketReenviarDTO Objeto);

        Task<JObject> GuardarMerge(FamiliaMergeDTO Objeto);

        Task<JObject> CambiarEstado(ActualizarDTO Objeto);
    }
}

