using ServicesDeskUCABWS.Models.DTO.TipoEstadoDTO;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models.DTO.EtiquetasDTO
{
	public class EtiquetaDTO
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		//public HashSet<TipoEstadoSearchDTO> tipoEstado { get; set; }
	}
}