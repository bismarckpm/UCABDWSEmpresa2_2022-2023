using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Models
{
    public class Rol
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
