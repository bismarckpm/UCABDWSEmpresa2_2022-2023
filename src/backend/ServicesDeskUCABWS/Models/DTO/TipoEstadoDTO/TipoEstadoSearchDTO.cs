using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models.DTO.TipoEstadoDTO
{
    public class TipoEstadoSearchDTO
    {
        public Guid Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public HashSet<Etiqueta> Etiqueta { get; set; }
    }
}
