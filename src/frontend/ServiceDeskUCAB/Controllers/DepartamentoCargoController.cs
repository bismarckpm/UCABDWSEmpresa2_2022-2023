using Microsoft.AspNetCore.Mvc;
using ServiceDeskUCAB.Models.DTO.CargoDTO;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.EstadoDTO;
using ServiceDeskUCAB.Servicios.DepartamentoEstado;
using ServiceDeskUCAB.Servicios.DepartamentosCargos;
using ServiceDeskUCAB.ViewModel.CargoDepartamento;
using ServiceDeskUCAB.ViewModel.EstadoDepartamento;

namespace ServiceDeskUCAB.Controllers
{
    public class DepartamentoCargoController : Controller
    {
        //Declaración de variables
        private readonly IDepartamentoCargoServicio _servicio;

        //Constructor
        public DepartamentoCargoController(IDepartamentoCargoServicio servicio)
        {
            _servicio = servicio;
        }

        public async Task<IActionResult> VistaCargosDepartamentos(Guid id, string nombre)
        {
            ViewModelCargoDepartamento viewModel = new ViewModelCargoDepartamento();
            viewModel.ListaCargos = await _servicio.ListaCargo(id);
            viewModel.Departamento = new DepartamentoSearchDTO()
            {
                Id = id.ToString(),
                nombre = nombre,
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarCargo(Guid id, string nombre, string descripcion, Guid idDept, string nombreDept)
        {

            var respuesta = await _servicio.EditarCargo(new CargoDTOUpdate()
            {
                Id = id,
                nombre_departamental = nombre,
                descripcion = descripcion
            });

            if (respuesta.Success)
            {
                return RedirectToAction("VistaCargosDepartamentos", new { id = idDept, nombre = nombreDept, message = "Cargo editado Corectamente" });
            }
            else
            {
                return RedirectToAction("VistaCargosDepartamentos", new { id = idDept, nombre = nombreDept, message = respuesta.Message });

            }
        }

        public async Task<IActionResult> DeshabilitarCargo(Guid Id, Guid IdDept, string nombreDept)
        {
            var respuesta = await _servicio.DeshabilitarCargo(Id);
            if (respuesta.Success)
            {
                return RedirectToAction("VistaCargosDepartamentos", new { id = IdDept, nombre = nombreDept, message = "Cargo deshabilitado Correctamente" });
            }
            else
            {
                return RedirectToAction("VistaCargosDepartamentos", new { id = IdDept, nombre = nombreDept, message = respuesta.Message});
            }
        }

        public async Task<IActionResult> HabilitarCargo(Guid Id, Guid IdDept, string nombreDept)
        {
            var respuesta = await _servicio.HabilitarCargo(Id);
            if (respuesta.Success)
            {
                return RedirectToAction("VistaCargosDepartamentos", new { id = IdDept, nombre = nombreDept, message = "Estado habilitado Correctamente" });
            }
            else
            {
                return RedirectToAction("VistaCargosDepartamentos", new { id = IdDept, nombre = nombreDept, message = respuesta.Message });
            }


        }
    }
}
