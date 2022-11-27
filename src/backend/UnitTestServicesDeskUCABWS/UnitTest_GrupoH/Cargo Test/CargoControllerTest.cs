using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.ControllerCargo;
using ServicesDeskUCABWS.Controllers.ControllerDepartamento;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.Cargo_Test
{
    [TestClass]
    public class CargoControllerTest
    {
        private readonly CargoController _controller;
        private readonly Mock<ICargoDAO> _serviceMock;
        public Cargo cargo = It.IsAny<Cargo>();
        public CargoDto cargoDto = It.IsAny<CargoDto>();

        public CargoControllerTest()
        {
            _serviceMock = new Mock<ICargoDAO>();
            _controller = new CargoController(_serviceMock.Object);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Cargo exitoso")]
        public void Crear()
        {
            var cargo = new CargoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarCargoDAO(It.IsAny<Cargo>())).Returns(new CargoDto());
            var application = new ApplicationResponse<CargoDto>();

            //act
            var result = _controller.AgregarCargoDAO(cargo);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }
    }
}
