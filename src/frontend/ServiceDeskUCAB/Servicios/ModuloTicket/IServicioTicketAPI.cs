using System;
using Newtonsoft.Json.Linq;
using ServicesDeskUCAB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceDeskUCAB.Models.DTO.TicketDTO;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.Tipo_TicketDTO;
using ServiceDeskUCAB.Models.TipoTicketsModels;
using ServiceDeskUCAB.Models.Response;

namespace ServiceDeskUCAB.Servicios
{
	public interface IServicioTicketAPI
	{
        Task<TicketCompletoDTO> Obtener(string ticketId);

        Task<List<TicketCompletoDTO>> FamiliaTicket(string ticketId);

        Task<List<BitacoraDTO>> BitacoraTicket(string ticketId);

        Task<List<TicketBasicoDTO>> Lista(string departamentoId, string opcion, string empleadoId);

        Task<List<DepartamentoSearchDTO>> Departamentos(string empleadoId);

        Task<List<Tipo_TicketDTOSearch>> TipoTickets(Guid idDepartamento);

        Task<List<TicketBasicoDTO>> TicketsEnviados(string idempleado);

        Task<ApplicationResponse<DepartamentoSearchDTO>> departamentoEmpleado(string empleadoId);

        Task<List<Estado>> DepartamentoEstados(string departamentoId);

        Task<JObject> TomarTicket(TicketTomarDTO objeto);

        Task<JObject> Finalizar(string ticketId);

        Task<JObject> Guardar(TicketDTO Objeto);

        Task<JObject> GuardarReenviar(TicketReenviarDTO Objeto);

        Task<JObject> GuardarMerge(FamiliaMergeDTO Objeto);

        Task<JObject> CambiarEstado(ActualizarDTO Objeto);

    }
}

