
using ServiceDeskUCAB.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models
{
    public class UsuariosRol
    {
        public Guid id { get; set; }
        public int cedula { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string fecha_nacimiento { get; set; }
        public string gender { get; set; }
        public string correo { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public List<Roles> roles { get; set; } = new List<Roles>();
        public string prueba { get; set; }
        public Rol Rol { get; set; }
    }

    public enum Gender
    {
        M,
        F
    }
    public enum Rol
    {
        Administrador,
        Usuario,
        Cliente
    }
}
