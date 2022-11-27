using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO
{
    public class Tipo_CargoDto
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string? nivel_jerarquia { get; set; } = "ninguno";
        public DateTime fecha_creacion { get; set; } = DateTime.Now.Date;
        public DateTime? fecha_ult_edic { get; set; } 
        public DateTime? fecha_eliminacion { get; set; }
    }
    public class Tipo_CargoDto_Update
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string? nivel_jerarquia { get; set; } = "ninguno";
        public DateTime? fecha_creacion { get; set; }
        public DateTime? fecha_ult_edic { get; set; } = DateTime.Now.Date;
        public DateTime? fecha_eliminacion { get; set; }

    }
}
