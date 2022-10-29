using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models.DTO.EtiquetaDTO
{
	public class EtiquetaDTO
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public HashSet<Tipo_Estado> ListaEstadosrelacionados { get; set; }
	}
}