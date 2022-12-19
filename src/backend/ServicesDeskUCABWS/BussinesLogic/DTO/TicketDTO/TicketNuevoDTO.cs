using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO
{
    public class TicketNuevoDTO
    {
        [Required]
        public string titulo { get; set; } = string.Empty;
        [Required]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public Guid empleado_id { get; set; }
        [Required]
        public Guid prioridad_id { get; set; }
        [Required]
        public Guid tipoTicket_id { get; set; }
        [Required]
        public Guid departamentoDestino_Id { get; set; }

        public Guid? ticketPadre_Id { get; set; }
    }
}
