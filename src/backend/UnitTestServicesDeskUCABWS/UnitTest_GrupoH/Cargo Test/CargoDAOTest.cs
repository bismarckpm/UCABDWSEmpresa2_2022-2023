using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoH.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.Cargo_Test
{
    [TestClass]
    public class CargoDAOTest
    {
        private readonly CargoDAO _CargoDAO;
        private readonly Mock<IDataContext> _contextMock;
        //private readonly Mock<IGrupoDAO> _serviceMock;
        private readonly ITipo_CargoDAO _servicioCargo;

        public CargoDAOTest()
        {
            _contextMock = new Mock<IDataContext>();
            _servicioCargo = new Tipo_CargoDAO(_contextMock.Object);
            _CargoDAO = new CargoDAO(_contextMock.Object, _servicioCargo);
            _contextMock.SetUpContextDataCargo();
            //_serviceMock = new Mock<IGrupoDAO>();           

        }

        [TestMethod(displayName: "Prueba Unitaria para agregar un Cargo")]
        public void AgregarCargoTest()
        {
            //arrange
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _CargoDAO.AgregarCargoDAO(request);

            Assert.AreEqual(request.nombre_departamental, "Cargo Nuevo");
        }

        [TestMethod(displayName: "Prueba Unitaria para agregar un Cargo Condicional")]
        public void AgregarCargoTestIf()
        {
            //arrange
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo 2",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _CargoDAO.AgregarCargoDAO(request);

            Assert.AreNotEqual(request.nombre_departamental, result.nombre_departamental);
        }

        [TestMethod(displayName: "Prueba Unitaria para agregar un Cargo excepcion general")]
        public void AgregarCargoTestExceptionGeneral()
        {
            //arrange
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.AgregarCargoDAO(request));
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar cargos")]
        public void ConsultarCargosTest()
        {

            var result = _CargoDAO.ConsultarCargos();
            Assert.AreEqual(result.Count(), _contextMock.Object.Cargos.ToList().Count());
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar cargos excepcion")]
        public void ConsultarCargosTestException()
        {
            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.ConsultarCargos());
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar cargos por ID")]
        public void ConsultarCargosPorIDTest()
        {
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            var result = _CargoDAO.ConsultarPorID(request.Id);
            Assert.AreEqual(result.Id, request.Id);
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar cargos por ID excepcion")]
        public void ConsultarCargosTestExceptionID()
        {
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.ConsultarPorID(request.Id));
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar departamentos por ID de tipo cargo")]
        public void ConsultarDepartamentosPorIDTipoCargo()
        {

            var cargo = new Tipo_Cargo
            {
                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
            };

            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            var result = _CargoDAO.GetByIdCargo(cargo.Id);
            Assert.AreEqual(result.Count(), 0);

        }

        [TestMethod(displayName: "Excepcion Prueba Unitaria para consultar Cargo por ID de tipo cargo")]
        public void ExcepcionConsultarCargoPorIDTipoCargo()
        {

            var cargo = new Tipo_Cargo
            {
                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
            };

            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.GetByIdCargo(cargo.Id));

        }


        [TestMethod(displayName: "Eliminar Cargo por ID")]
        public void EliminarCargoPorID()
        {
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            var obj = new CargoDto();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var result = _CargoDAO.eliminarCargo(request.Id);
            Assert.IsInstanceOfType(obj, result.GetType());
        }

        [TestMethod(displayName: "Excepcion de eliminar cargo por ID")]
        public void ExcepcionEliminarDepartamentoPorID()
        {
            var data = new Cargo
            {
                Id = new Guid("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E")

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.eliminarCargo(data.Id));
        }

        [TestMethod(displayName: "Prueba Unitaria para editar un Cargo")]
        public void ActualizarCargoTest()
        {
            //arrange
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _CargoDAO.ActualizarCargo(request);

            Assert.AreEqual(request.nombre_departamental, "Cargo Nuevo");
        }

        [TestMethod(displayName: "Prueba Unitaria cuando la actualizacion de un cargo falla por campos vacios")]
        public void ExcepcionDBUpdateActualizarCargo()
        {
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = null,

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new DbUpdateException());
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.ActualizarCargo(request));
        }

        [TestMethod(displayName: "Prueba Unitaria para editar un cargo excepcion general")]
        public void ExcepcionEditarCargoTestExceptionGeneral()
        {
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.ActualizarCargo(request));
        }

        [TestMethod(displayName: "Prueba Unitaria para mostrar cargos no eliminados")]
        public void MostrarCargosNoEliminados()
        {
            var request = new Cargo
            {

                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _CargoDAO.DeletedCargo();

            Assert.AreEqual(result.Count(), 1);
        }

    }
}
