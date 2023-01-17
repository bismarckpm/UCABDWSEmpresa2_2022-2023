using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using UnitTestServicesDeskUCABWS.DataSeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.UnitTestUsuario
{
    [TestClass]
    public class AsignarRevocarCargosTest
    {
        private readonly UsuarioDAO _userService;
        private readonly Mock<IDataContext> _contextMock;
        private readonly IMapper mapper;

        public AsignarRevocarCargosTest()
        {
            var myProfile = new List<Profile>
            {
                new TipoEstadoMapper(),
                new EtiquetaMapper(),
                new EtiquetaTipoEstadoMapper(),
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            mapper = new Mapper(configuration);
            _contextMock = new Mock<IDataContext>();
            _userService = new UsuarioDAO(_contextMock.Object, mapper);
            _contextMock.SetupDbContextData();
        }

        //Asignar Cargos
        [TestMethod(displayName: "Prueba Unitaria para asignar un cargo a un usuario")]
        public void AsignarCargoCaminoFeliz()
        {
            //arrange
            var requestUserAdmin = new UsuarioDTOAsignarCargo()
            {
                idCargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"),
                idUsuario = Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE85D1")
            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _userService.AsignarCargo(requestUserAdmin);

            Assert.IsTrue(result is UsuarioDTOAsignarCargo);
        }

        [TestMethod(displayName: "Prueba Unitaria para cuando no se encontro el cargo")]
        public void AsignarCargoNoEncontroCargo()
        {
            //arrange
            var requestUserAdmin = new UsuarioDTOAsignarCargo()
            {
                idCargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0003C"),
                idUsuario = Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE85D1")
            };
            var expected = new ExceptionsControl();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            try
            {
                _userService.AsignarCargo(requestUserAdmin);
            }
            catch (ExceptionsControl ex)
            {
                expected = ex;
            }

            Assert.AreEqual(expected.Mensaje, "No se encontro el cargo ingresado");
        }

        [TestMethod(displayName: "Prueba Unitaria para cuando no se encontro el usuario")]
        public void AsignarCargoNoEncontroUsuario()
        {
            //arrange
            var requestUserAdmin = new UsuarioDTOAsignarCargo()
            {
                idCargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"),
                idUsuario = Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE95D1")
            };
            var expected = new ExceptionsControl();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            try
            {
                _userService.AsignarCargo(requestUserAdmin);
            }
            catch (ExceptionsControl ex)
            {
                expected = ex;
            }

            Assert.AreEqual(expected.Mensaje, "No se encontro el usuario ingresado");
        }

        [TestMethod(displayName: "Prueba Unitaria para cuando el formato de los ID no es correcto")]
        public void AsignarCargoErrorFormato()
        {
            //arrange
            var requestUserAdmin = new UsuarioDTOAsignarCargo()
            {
                idCargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"),
                idUsuario = Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE95D1")
            };
            var expected = new ExceptionsControl();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(set => set.Cargos.Find(It.IsAny<Guid>())).Throws(new FormatException());
            try
            {
                _userService.AsignarCargo(requestUserAdmin);
            }
            catch (ExceptionsControl ex)
            {
                expected = ex;
            }

            Assert.AreEqual(expected.Mensaje, "Formato no valido");
        }

        [TestMethod(displayName: "Prueba Unitaria para cuando se genera un error no previsto")]
        public void AsignarCargoException()
        {
            //arrange
            var requestUserAdmin = new UsuarioDTOAsignarCargo()
            {
                idCargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"),
                idUsuario = Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE95D1")
            };
            var expected = new ExceptionsControl();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(set => set.Cargos).Throws(new Exception());
            try
            {
                _userService.AsignarCargo(requestUserAdmin);
            }
            catch (ExceptionsControl ex)
            {
                expected = ex;
            }

            Assert.AreEqual(expected.Mensaje, "No se pudo actualizar el cargo por error desconocido.");
        }


        //Revocar Cargo
        [TestMethod(displayName: "Prueba Unitaria para revocar un cargo a un usuario")]
        public void RevocarCargoCaminoFeliz()
        {
            //arrange

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _userService.RevocarCargo(Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE85D1"));

            Assert.AreEqual("0F636FB4-7F04-4A2E-B2C2-359B99BE85D1",result.ToUpper());
        }

        [TestMethod(displayName: "Prueba Unitaria para cuando no se encontro el usuario en revocar")]
        public void RevocarCargoNoEncontroUsuario()
        {
            //arrangE
            var expected = new ExceptionsControl();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            try
            {
                _userService.RevocarCargo(Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE95D1"));
            }
            catch (ExceptionsControl ex)
            {
                expected = ex;
            }

            Assert.AreEqual(expected.Mensaje, "No se encontro el usuario ingresado");
        }

        [TestMethod(displayName: "Prueba Unitaria para cuando se genera un error no previsto en revocar")]
        public void RevocarCargoException()
        {
            //arrange
            var expected = new ExceptionsControl();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(set => set.Empleados).Throws(new Exception());
            try
            {
                _userService.RevocarCargo(Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"));
            }
            catch (ExceptionsControl ex)
            {
                expected = ex;
            }

            Assert.AreEqual(expected.Mensaje, "No se pudo actualizar el cargo por error desconocido.");
        }


        [TestMethod(displayName: "Prueba Unitaria para cuando el formato de los ID no es correcto en revocar")]
        public void RevocarCargoErrorFormato()
        {
            //arrange
            var expected = new ExceptionsControl();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(set => set.Empleados).Throws(new FormatException());
            try
            {
                _userService.RevocarCargo(Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE85D1"));
            }
            catch (ExceptionsControl ex)
            {
                expected = ex;
            }

            Assert.AreEqual(expected.Mensaje, "Formato no valido");
        }

        //Consultar Empleado
        [TestMethod]
        public void ConsultarEmpleado()
        {
            //act 
            var result = _userService.ObtenerEmpleados();

            //assert
            Assert.AreEqual(result.Count,9);
        }

        [TestMethod]
        [ExpectedException(typeof(ExceptionsControl))]
        public void ConsultarEmpleadoException()
        {
            _contextMock.Setup(x=>x.Empleados).Throws<FormatException>();
            //act 
            var result = _userService.ObtenerEmpleados();
        }


    }
}
