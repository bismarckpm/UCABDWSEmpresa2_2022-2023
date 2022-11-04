using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.Servicios
{
    public interface IServicio_API
    {

        Task<List<Tipo>> Lista();
        Task<bool> Eliminar(int idProducto);

    }
}
