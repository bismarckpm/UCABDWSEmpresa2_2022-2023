namespace ServiceDeskUCAB.Models.Modelos_de_Usuario
{
    public class Roles
    {
        public Guid idusuario { get; set; } = Guid.Empty;
        public Guid idrol { get; set; } = Guid.Empty;
        public RolDTO Rol { get; set; }
    }
}
