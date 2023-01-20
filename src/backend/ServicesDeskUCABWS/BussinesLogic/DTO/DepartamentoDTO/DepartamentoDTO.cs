using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO
{
    public class DepartamentoDto
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; } = DateTime.Now.Date;
		public DateTime? fecha_ultima_edicion { get; set; } 
        public DateTime? fecha_eliminacion { get; set; }
    }

    public class DepartamentoDto_Update
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_ultima_edicion { get; set; } = DateTime.Now.Date;
        public DateTime? fecha_eliminacion { get; set; }

        [JsonIgnore]
        public Guid? id_grupo { get; set; } = null;
    }

    public class DepartamentoCargoDTO
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public List<CargoDTOUpdate> Cargo { get; set; }
    }
}