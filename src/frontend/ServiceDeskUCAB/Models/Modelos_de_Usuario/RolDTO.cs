using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ServiceDeskUCAB.Models.Modelos_de_Usuario
{
    public class RolDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    
    }
}
