using ServiceDeskUCAB.Models.EstadoTicket;
using System.Collections.Generic;

namespace ServiceDeskUCAB.ViewModel.EstadoTicket
{
    public class EstadoEditarViewModel
    {
        public List<Etiqueta> Etiquetas { get; set; }
        public TipoEstado Estado { get; set; }
        public string Message { get; set; }
    }
}