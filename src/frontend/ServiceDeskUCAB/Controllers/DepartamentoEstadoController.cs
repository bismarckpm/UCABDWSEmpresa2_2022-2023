using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.EstadoDTO;
using ServiceDeskUCAB.Servicios.DepartamentoEstado;
using ServiceDeskUCAB.ViewModel.EstadoDepartamento;

namespace ServiceDeskUCAB.Controllers
{
    public class DepartamentoEstadoController : Controller
    {
        //Declaración de variables
        private readonly IServicioDepartamentoEstado _servicio;

        //Constructor
        public DepartamentoEstadoController(IServicioDepartamentoEstado servicio)
        {
            _servicio = servicio;
        }

        public async Task<IActionResult> VistaEstadosDepartamentos(Guid id, string nombre)
        {
            ViewModelEstadoDepartamento viewModel = new ViewModelEstadoDepartamento();
            viewModel.ListaEstado = await _servicio.ListaEstado(id);
            viewModel.Departamento = new DepartamentoSearchDTO()
            {
                Id = id.ToString(),
                nombre = nombre,
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarEstado(Guid id, string nombre, string descripcion, Guid idDept, string nombreDept)
        {

            var respuesta = await _servicio.EditarEstado(new EstadoDTOUpdate()
            {
                Id = id,
                nombre = nombre,
                descripcion = descripcion
            });

            if (respuesta.Success)
            {
                return RedirectToAction("VistaEstadosDepartamentos", new { id = idDept, nombre = nombreDept, message = "Estado editado Corectamente" });
            }
            else
            {
                return RedirectToAction("VistaEstadosDepartamentos", new { id = idDept, nombre = nombreDept, message = respuesta.Message });

            }
        }


    }
}

