using System;


namespace ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta
{
	public class EtiquetaDTO
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		//public HashSet<TipoEstadoSearchDTO> tipoEstado { get; set; }
	}
}