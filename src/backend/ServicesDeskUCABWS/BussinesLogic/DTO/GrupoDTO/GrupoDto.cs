using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO
{
    public class GrupoDto
    {
        public Guid id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; } = DateTime.Now.Date;
        public DateTime? fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
    }

    public class GrupoDto_Update
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime? fecha_ultima_edicion { get; set; } = DateTime.Now.Date;
    }
}
