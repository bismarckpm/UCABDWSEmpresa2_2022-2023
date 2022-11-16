namespace ServiceDeskUCAB.Models
{
    public class CrearUsuario
    {
        public int cedula { get; set; }
        public string primer_nombre { get; set; } = string.Empty;
        public string segundo_nombre { get; set; } = string.Empty;
        public string primer_apellido { get; set; } = string.Empty;
        public string segundo_apellido { get; set; } = string.Empty;
        public string fecha_nacimiento { get; set; }
        public string gender { get; set; }
        public string correo { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
    }
}
