namespace ServiceDeskUCAB.Models.ViewModel
{
    public class TipoNuevoViewModel
    {
        public List<Tipo> ListaTipo { get; set; }

        public Tipo tipo { get; set; }
        public List<TipoCargoNuevo> tipoCargoNuevo { get; set; }

        public List<Departament> ListaDepartamento { get; set; }

        public List<TipoCargo> ListaCargos { get; set; }

    }
}
