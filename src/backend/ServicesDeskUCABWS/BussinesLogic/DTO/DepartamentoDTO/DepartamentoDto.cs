using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO
{
    public class DepartamentoDto
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }

        //public Grupo Grupo { get; set; }
    }

    public class DepartamentoDto_Update
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_ultima_edicion { get; set; } = DateTime.Now.Date;
        public DateTime? fecha_eliminacion { get; set; }


    }

}
