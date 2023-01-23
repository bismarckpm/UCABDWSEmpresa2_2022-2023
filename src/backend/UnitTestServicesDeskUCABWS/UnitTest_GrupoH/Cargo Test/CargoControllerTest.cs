using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
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
            var cargo = new CargoDTOCreate()
            {


                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarCargoDAO(It.IsAny<CargoDTOCreate>())).Returns(new CargoDTOCreate());
            var application = new ApplicationResponse<CargoDTOCreate>();

            //act
            //var result = _controller.AgregarCargoDAO(cargo);

            //assert
            //Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Cargo excepcion")]
        public void CrearDepartamentoExcepcion()
        {

            var cargo = new CargoDTOCreate()
            {

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",
                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")
                
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarCargoDAO(It.IsAny<CargoDTOCreate>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            //var ex = _controller.AgregarCargoDAO(cargo);

            //assert
            //Assert.IsNotNull(ex);
            //Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar los cargos")]
        public void ConsultarCargos()
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
            _serviceMock.Setup(p => p.ConsultarCargos()).Returns(new List<CargoDto>());
            var application = new ApplicationResponse<List<CargoDto>>();

            //act
            var result = _controller.ConsultarCargos();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Cargos excepcion")]
        public void ConsultarDepartamentosExcepcion()
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
            _serviceMock.Setup(p => p.ConsultarCargos()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarCargos();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        /*TestMethod(displayName: "Prueba Unitaria Controlador para eliminar cargo exitoso")]
        public void EliminarCargo()
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
            _serviceMock.Setup(p => p.eliminarCargo(It.IsAny<Guid>())).Returns(new CargoDto());
            var application = new ApplicationResponse<CargoDto>();

            //act
            var result = _controller.eliminarCargo(cargo.id);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }*/

        /*[TestMethod(displayName: "Prueba Unitaria Controlador para eliminar Cargos excepcion")]
        public void EliminarCargosExcepcion()
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
            _serviceMock.Setup(p => p.eliminarCargo(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.eliminarCargo(cargo.id);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }*/

        [TestMethod(displayName: "Prueba Unitaria Controlador para modificar cargo exitoso")]
        public void ActualizarCargo()
        {
            var cargo = new CargoDto_Update()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = DateTime.Now.Date,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.ActualizarCargo(It.IsAny<Cargo>())).Returns(new CargoDto_Update());
            var application = new ApplicationResponse<CargoDto_Update>();

            //act
            var result = _controller.ActualizarCargo(cargo);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para actualizar Cargos excepcion")]
        public void ActualizarCargosExcepcion()
        {

            var cargo = new CargoDto_Update()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c89"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = DateTime.Now.Date,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.ActualizarCargo(It.IsAny<Cargo>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ActualizarCargo(cargo);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para modificar cargo por id exitoso")]
        public void ConsultarCargoPorID()
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
            _serviceMock.Setup(p => p.ConsultarPorID(It.IsAny<Guid>())).Returns(new CargoDto());
            var application = new ApplicationResponse<CargoDto>();

            //act
            var result = _controller.ConsultarPorID(cargo.id);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        /*[TestMethod(displayName: "Prueba Unitaria Controlador para consultar Cargo por id de cargo excepcion")]
        public void ExcepcionConsultarDepartamentoPorID()
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
            _serviceMock.Setup(p => p.AgregarCargoDAO(It.IsAny<CargoDTOCreate>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.AgregarCargoDAO(cargo);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }*/

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Cargo exitoso")]
        public void CrearCargo()
        {
            var cargo = new CargoDTOCreate()
            {


                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarCargoDAO(It.IsAny<CargoDTOCreate>())).Returns(new CargoDTOCreate());
            var application = new ApplicationResponse<CargoDTOCreate>();

            //act
            var result = _controller.AgregarCargoDAO(cargo);


            //assert
            //Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Cargo excepcion")]
        
        public void CrearCargoExcepcion()
        {

            var cargo = new CargoDTOCreate()
            {

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",
                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")

            };

            //arrange
            _serviceMock.Setup(p => p.AgregarCargoDAO(It.IsAny<CargoDTOCreate>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.AgregarCargoDAO(cargo);

            Assert.IsTrue(ex.Success == false);
        }

        //Consultar Por Departamento
        [TestMethod]
        public void TestConsultarCargosPorDepartamento()
        {
            var cargo = new CargoDTOCreate()
            {


                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")
            };

            //arrange
            _serviceMock.Setup(p => p.ConsultarCargosDepartamento(It.IsAny<Guid>())).Returns(new List<CargoDTOUpdate>());

            //act
            var result = _controller.ConsultarCargosPorDepartamento(new Guid());

            Assert.IsTrue(result.Success == true);
            //assert
            //Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod]

        public void TestConsultarCargosPorDepartamentoException()
        {

            var cargo = new CargoDTOCreate()
            {

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",
                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")

            };

            //arrange
            _serviceMock.Setup(p => p.ConsultarCargosDepartamento(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarCargosPorDepartamento(new Guid());

            Assert.IsTrue(ex.Success == false);
        }

    }
}
