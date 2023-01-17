using System;
namespace ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO
{
	public class TicketReenviarDTO
	{
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int? nro_cargo_actual { get; set; }
        public Guid empleado_id { get; set; }
        public Guid prioridad_id { get; set; }
        public Guid tipoTicket_id { get; set; }
        public Guid departamentoDestino_Id { get; set; }
        public Guid? ticketPadre_Id { get; set; }

    }
}

