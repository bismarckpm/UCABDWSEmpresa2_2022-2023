using System;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO
{
    public class CargoDto
    {
        
            public Guid Id { get; set; }
            public string nombre_departamental { get; set; }
            public string descripcion { get; set; }
            public DateTime fecha_creacion { get; set; } = DateTime.Now.Date;
            public DateTime? fecha_ultima_edicion { get; set; }
            public DateTime? fecha_eliminacion { get; set; }
        
            
    }

    public class CargoDto_Update
    {
        public Guid id { get; set; }
        public string nombre_departamental { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_ultima_edicion { get; set; } = DateTime.Now.Date;
        public DateTime? fecha_eliminacion { get; set; }

        [JsonIgnore]
        public Guid? id_tipo { get; set; } = null;


    }
}
