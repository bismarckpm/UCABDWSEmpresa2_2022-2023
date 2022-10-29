using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ServicesDeskUCABWS.Models.DTO
{
	public class DepartamentoDto
	{

		public Guid Id { get; set; }

		public string nombre { get; set; }


		public string descripcion { get; set; }


		public DateTime fecha_creacion { get; set; }
		public DateTime fecha_ultima_edicion { get; set; }
		public DateTime? fecha_eliminacion { get; set; }


		public Grupo Grupo { get; set; }
	}
}
