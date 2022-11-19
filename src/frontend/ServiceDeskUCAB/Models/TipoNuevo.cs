using Newtonsoft.Json;

namespace ServiceDeskUCAB.Models
{
    public class TipoNuevo
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<TipoCargoNuevo>? flujo_Aprobacion { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string>? departamento { get; set; }
        public int? minimo_Aprobado { get; set; }
        public int? maximo_Rechazado { get; set; }

    }
}