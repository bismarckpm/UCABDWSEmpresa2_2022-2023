using System;
namespace ServiceDeskUCAB.Models
{
	public class BitacoraDTO
	{
        public Guid Id { get; set; }
        public string estado_nombre { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
    }
}

