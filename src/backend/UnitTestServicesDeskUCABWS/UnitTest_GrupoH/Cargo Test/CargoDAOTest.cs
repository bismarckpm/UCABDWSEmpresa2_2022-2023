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
        private readonly CargoService _CargoDAO;
        private readonly Mock<IDataContext> _contextMock;
        private readonly Mock<IDataContext> _contextMockCTC;
        private readonly ITipo_CargoDAO _servicioTipoCargo;
        private readonly ITipo_CargoDAO _servicioCargo;
        
        public CargoDAOTest()
        {
            _contextMock = new Mock<IDataContext>();
            _contextMockCTC = new Mock<IDataContext>();
            _servicioCargo = new Tipo_CargoDAO(_contextMockCTC.Object);
            _CargoDAO = new CargoService(_contextMock.Object);
            _contextMock.SetUpContextDataCargo();
            _contextMockCTC.SetUpContextDataCargo_TipoCargo();                    

        }

        [TestMethod(displayName: "Prueba Unitaria para agregar un Cargo")]
        public void AgregarCargoTest()
        {
            //arrange
            var request = new CargoDTOCreate
            {


                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")
            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(set => set.Departamentos.Find(It.IsAny<Guid>())).Returns(new Departamento());

            var result = _CargoDAO.AgregarCargoDAO(request);

            Assert.AreEqual(request.nombre_departamental, "Cargo Nuevo");
        }

        /*[TestMethod(displayName: "Prueba Unitaria para agregar un Cargo Condicional")]
        public void AgregarCargoTestIf()
        {
            //arrange
            var request = new CargoDTOCreate
            {

                nombre_departamental = "Cargo Nuevo 2",

                descripcion = "Es un cargo",

                idDepartamento= Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            _contextMock.Setup(set => set.Departamentos.Find(It.IsAny<Guid>())).Returns(null as Departamento);

            var result = _CargoDAO.AgregarCargoDAO(request);

            Assert.AreNotEqual(request.nombre_departamental, result.nombre_departamental);
        }*/

        [TestMethod(displayName: "Prueba Unitaria para agregar un Cargo excepcion general")]
        public void AgregarCargoTestExceptionGeneral()
        {
            //arrange
            var request = new CargoDTOCreate
            {


                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                idDepartamento = Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")

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

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            var result = _CargoDAO.ConsultarPorID(request.id);
            Assert.AreEqual(result.id, request.id);
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar cargos por ID excepcion")]
        public void ConsultarCargosTestExceptionID()
        {
            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.ConsultarPorID(request.id));
        }

        /*[TestMethod(displayName: "Prueba Unitaria para consultar departamentos por ID de tipo cargo")]
        public void ConsultarDepartamentosPorIDTipoCargo()
        {

            var cargo = new Tipo_Cargo
            {
                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
            };

            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            var result = _CargoDAO.GetByIdCargo(cargo.id);
            Assert.AreEqual(result.Count(), 1);

        }*/

        /*[TestMethod(displayName: "Excepcion Prueba Unitaria para consultar Cargo por ID de tipo cargo")]
        public void ExcepcionConsultarCargoPorIDTipoCargo()
        {

            var cargo = new Tipo_Cargo
            {
                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
            };

            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.GetByIdCargo(cargo.id));

        }*/


        /*[TestMethod(displayName: "Eliminar Cargo por ID")]
        public void EliminarCargoPorID()
        {
            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            var obj = new CargoDto();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var result = _CargoDAO.eliminarCargo(request.id);
            Assert.IsInstanceOfType(obj, result.GetType());
        }*/

       /*[TestMethod(displayName: "Excepcion de eliminar cargo por ID")]
        public void ExcepcionEliminarDepartamentoPorID()
        {
            var data = new Cargo
            {
                id = new Guid("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E")

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.eliminarCargo(data.id));
        }*/

        [TestMethod(displayName: "Prueba Unitaria para editar un Cargo")]
        public void ActualizarCargoTest()
        {
            //arrange
            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

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

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

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

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

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

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

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

        [TestMethod(displayName: "Prueba Unitaria para mostrar cargos no eliminados excepcion")]
        public void ExcepcionMostrarCargosNoEliminados()
        {
            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.DeletedCargo());
        }

        [TestMethod(displayName: "Prueba Unitaria para mostrar cargos no asociados a un tipo cargo")]
        public void MostrarCargosNoAsociados()
        {
            
            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.DeletedCargo());
        }

        /*[TestMethod(displayName: "Prueba Unitaria para asociar grupos a cargos")]
        public void AsignarTipoCargoACargo()
        {

            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _CargoDAO.AsignarTipoCargotoCargo(request.id, request.id.ToString());

            Assert.AreEqual(result.Count(), 1);
        }*/

       /* [TestMethod(displayName: "Prueba Unitaria para asociar tipo cargo a cargo excepcion")]
        public void ExcepcionAsignarTipoCargoACargo()
        {

            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.AsignarTipoCargotoCargo(request.id, request.id.ToString()));
        }*/

        /*[TestMethod(displayName: "Prueba Unitaria para listar los cargos que no están asociados a un tipo cargo")]
        public void NoAsociado()
        {

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _CargoDAO.NoAsociado();

            Assert.AreEqual(result.Count(), 1);
        }*/

        /*[TestMethod(displayName: "Prueba Unitaria para listar los cargos que no están asociados a un tipo cargo excepcion")]
        public void ExcepcionNoAsociado()
        {            
            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.NoAsociado());
        }*/

        /*[TestMethod(displayName: "Prueba Unitaria para editar relacion de los cargos con los tipos de cargos con lista de IDs de Departamentos vacios")]
        public void EditarRelacionPrimerCondicional()
        {

            _contextMockCTC.Setup(set => set.DbContext.SaveChanges());
            var result = _CargoDAO.EditarRelacion(It.IsAny<Guid>(), String.Empty);
            Assert.AreEqual(result.Count, 1);
        }
        */
        /*[TestMethod(displayName: "Prueba Unitaria para editar relacion de los cargos con los tipo cargos con lista de IDs de asignado")]
        public void EditarRelacionElse()
        {

            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date

            };


            _contextMockCTC.Setup(set => set.DbContext.SaveChanges());
            var result = _CargoDAO.EditarRelacion(It.IsAny<Guid>(), request.id.ToString());
            Assert.AreEqual(result.Count, 1);
        }*/

        /*[TestMethod(displayName: "Prueba Unitaria para la excepcion de editar relacion de los cargos con los tipo de cargos")]
        public void ExcepcionEditarRelacion()
        {
            var tipo_cargo = new Tipo_Cargo
            {
                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")
            };

            var request = new Cargo
            {


                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.EditarRelacion(tipo_cargo.id, request.id.ToString()));
        }*/

        [TestMethod(displayName: "Prueba Unitaria para verificar existencia de cargo")]
        public void ExisteCargo()
        {


            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date

            };


            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var result = _CargoDAO.ExisteCargo(request);
            Assert.IsTrue(result);
        }

        [TestMethod(displayName: "Prueba Unitaria para verificar existencia de cargos con excepcion")]
        public void ExcepcionExisteCargos()
        {

            var request = new Cargo
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre_departamental = "Cargo Nuevo",

                descripcion = "Es un cargo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date

            };

            _contextMock.Setup(p => p.Cargos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _CargoDAO.ExisteCargo(request));
        }

    }
}
