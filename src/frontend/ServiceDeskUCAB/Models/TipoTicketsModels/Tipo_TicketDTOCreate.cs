
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServicesDeskUCAB.Models.TipoTicketModels
{
    public class Tipo_TicketDTOCreate
    {

        public string nombre { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public string tipo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<FlujoAprobacionDTOCreate> Flujo_Aprobacion { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Departamento { get; set; }
        public int? Minimo_Aprobado { get; set; }
        public int? Maximo_Rechazado { get; set; }
    }

}
