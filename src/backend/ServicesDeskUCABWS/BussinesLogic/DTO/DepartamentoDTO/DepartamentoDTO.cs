using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO
{
    public class DepartamentoDTO
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
    }
}
