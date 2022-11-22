namespace ServiceDeskUCAB.Models.TipoTicketsModels
{
    public class TipoCargo
    {
        public Guid Id { get; set; }

        public string nombre { get; set; } = string.Empty;

        public int posicion { get; set; }

        public bool activado { get; set; } = false;


    }
}
