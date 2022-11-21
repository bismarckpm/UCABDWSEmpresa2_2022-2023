using System;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.Entities
{
    public class RolUsuario
    {
        public Guid UserId { get; set; }
        [JsonIgnore]
        public Usuario User { get; set; }
        public Guid RolId { get; set; }
        [JsonIgnore]
        public Rol Rol { get; set; }
    }
}
