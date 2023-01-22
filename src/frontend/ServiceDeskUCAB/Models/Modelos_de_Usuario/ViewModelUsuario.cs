using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;

namespace ServiceDeskUCAB.Models.Modelos_de_Usuario
{
    public class ViewModelUsuario
    {
        public List<UsuariosRol> ListaUsuario { get; set; }
        public List<DepartamentoCargoDTO> ListaDepartamento { get; set; }
    }
}
