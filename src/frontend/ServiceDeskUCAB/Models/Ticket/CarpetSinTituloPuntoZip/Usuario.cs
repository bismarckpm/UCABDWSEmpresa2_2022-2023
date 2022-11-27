using System;
using System.Collections.Generic;

namespace ServicesDeskUCAB.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public int Cedula { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Gender { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
        public DateTime FechaEliminacion { get; set; }

        public ICollection<Ticket> Lista_Ticket { get; set; }
    }
}

