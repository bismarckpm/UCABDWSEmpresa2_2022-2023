namespace ProyectD.Models
{
    public class Tipo_Ticket
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string tipo { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_ult_edic { get; set; }
        public DateTime fecha_elim { get; set; }
        public HashSet<Flujo_Aprobacion> Flujo_Aprobacion { get; set; }
        public HashSet<Departamento> Departamento { get; set; }
    }
}
