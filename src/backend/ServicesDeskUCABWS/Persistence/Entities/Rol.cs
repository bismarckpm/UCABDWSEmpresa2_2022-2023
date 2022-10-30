using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ServicesDeskUCABWS.Persistence.Entities
{
    public class Rol
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<RolUsuario> Usuarios { get; set; }
    }
    public enum JsonIgnoreCondition
    {
        Never,
    };
}
