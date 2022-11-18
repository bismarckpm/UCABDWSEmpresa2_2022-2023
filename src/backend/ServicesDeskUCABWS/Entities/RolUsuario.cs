using System;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.Entities
{
    public class RolUsuario
    {
        public Guid userid { get; set; }
        [JsonIgnore]
        public Usuario User { get; set; }
        public Guid rolid { get; set; }
        [JsonIgnore]
        public Rol Rol { get; set; }
    }
}
