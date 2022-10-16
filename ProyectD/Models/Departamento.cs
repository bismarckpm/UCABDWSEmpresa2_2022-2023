namespace ProyectD.Models
{
    public class Departamento
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ult_edic { get; set; }
        public DateTime fecha_elim { get; set; }
        public HashSet<Tipo_Ticket> Tipo_Ticket { get; set; }
    }
}
