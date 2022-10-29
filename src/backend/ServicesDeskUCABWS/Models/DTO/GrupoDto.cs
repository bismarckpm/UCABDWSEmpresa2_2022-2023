using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Models.DTO
{
	public class GrupoDto
	{
	
		public Guid Id { get; set; }
		public string nombre { get; set; } = string.Empty;
		public string descripcion { get; set; } = string.Empty;

		public DateTime fecha_creacion { get; set; }
		public DateTime fecha_ultima_edicion { get; set; }
		public DateTime? fecha_eliminacion { get; set; }
	}
}
