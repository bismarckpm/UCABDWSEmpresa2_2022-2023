using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public interface ITicketDAO
    {
        //public ApplicationResponse<TicketCreateDTO> RegistroTicket(TicketCreateDTO ticketDTO);
        public ApplicationResponse<TicketNuevoDTO> RegistroTicket(TicketNuevoDTO ticketDTO);
        public List<Ticket> ConsultaListaTickets();
        public Ticket ConsultaTicket(Guid id);

        //public ApplicationResponse<Votos_TicketDTOCreate> RegistroVotos(Votos_TicketDTOCreate votos_TicketDTO);
        public ApplicationResponse<string> crearTicket(TicketNuevoDTO nuevoTicket);
        public ApplicationResponse<TicketInfoCompletaDTO> obtenerTicketPorId(Guid id);
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamento(Guid idDepartamento, string estado, Guid empleadoId);
        public ApplicationResponse<string> cambiarEstadoTicket(Guid ticketId, Guid estadoId);
        public ApplicationResponse<List<TicketBitacorasDTO>> obtenerBitacoras(Guid ticketId);
        public ApplicationResponse<string> mergeTickets(Guid ticketPrincipalId, List<Guid> ticketsSecundariosId);
        public ApplicationResponse<string> reenviarTicket(TicketReenviarDTO solicitudTicket);
        public ApplicationResponse<List<TicketInfoCompletaDTO>> obtenerFamiliaTicket(Guid ticketPrincipalId);
        public ApplicationResponse<string> eliminarTicket(Guid id);
        public ApplicationResponse<List<DepartamentoSearchDTO>> buscarDepartamentos(Guid id);
        public ApplicationResponse<DepartamentoSearchDTO> buscarDepartamentoEmpleado(Guid idEmpleado);
        public ApplicationResponse<List<Tipo_TicketDTOSearch>> buscarTipoTickets(Guid id);
        public ApplicationResponse<List<Tipo_Ticket>> buscarTiposTickets();
        public ApplicationResponse<List<Estado>> buscarEstadosPorDepartamento(Guid idDepartamento);
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPropios(Guid idEmpleado);
        public ApplicationResponse<string> adquirirTicket(TicketTomarDTO ticketPropio);
        public bool CambiarEstado(Ticket ticketLlegada, string Estado, List<Empleado> ListaEmpleados);
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsEnviados(Guid idEmpleado);
    }
}
