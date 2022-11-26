using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoI.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.UnitTestRolUsuario
{
    [TestClass]
    public class RolUsuarioServiceTest
    {
        private readonly UserRolDAO _userService;
        private readonly Mock<IDataContext> _contextMock;

        public RolUsuarioServiceTest()
        {
            _contextMock = new Mock<IDataContext>();
            _userService = new UserRolDAO(_contextMock.Object);
            _contextMock.SetupDataContextRolUser();
        }

        [TestMethod(displayName: "Prueba unitaria consultar roles")]
        public void ConsultarRolusuarioUnitTest()
        {
            var result = _userService.ObtenerUsuariosRoles();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod(displayName: "Prueba unitaria  para exception en consulta de rol usuarios")]
        public void ConsultarRolusuarioExeptionUnitTest()

        {
            _contextMock.Setup(p => p.RolUsuarios).Throws(new Exception());
            Assert.ThrowsException<ExceptionsControl>(() => _userService.ObtenerUsuariosRoles());
        }

        [TestMethod(displayName: "Prueba Unitaria intentar eliminar un rol de un usuario que no existe")]
        public void EliminarRolUsuarioExeptionTest()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");
            _contextMock.Setup(p => p.RolUsuarios).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.EliminarRol(id));
        }

        [TestMethod(displayName: "Prueba Unitaria para eliminar un rol de un usuario")]
        public void EliminarRolUsuarioExceptionTest()
        {
            var id_usuario = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");
            var id_rol = new Guid("8C8A156B-7383-4610-8539-30CCF7298162");
            var obj = new RolUsuarioDTO();
            var result = _userService.EliminarRol(id_usuario);
            Assert.IsInstanceOfType(obj, result.GetType());

        }

        [TestMethod(displayName: "Prueba unitaria para consultar rol de un usuario por ID ")]
        public void ConsultarUsuarioByID()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");

            var result = _userService.consularRolID(id);

            Assert.AreEqual(result.idusuario, id);
        }

        [TestMethod(displayName: "Prueba unitaria para consultar rol de un usuario que no existe ")]
        public void ConsultarUsuarioByIDException()
        {
            Assert.ThrowsException<ExceptionsControl>(() => _userService.consularRolID(new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC122")));
        }

        [TestMethod(displayName: "Prueba unitaria agregar un rol a un usuario ")]
        public void AgregarRolUsuarioTest()
        {
            var UsuarioClient = new RolUsuario
            {
                UserId = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC192"),
                RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298163")
            };

            _contextMock.Setup(r => r.RolUsuarios.Add(UsuarioClient));

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _userService.AgregarRol(UsuarioClient);

            Assert.IsInstanceOfType(UsuarioClient, result.GetType());
        }

        [TestMethod(displayName: "Prueba unitaria agregar un rol a un usuario existente")]
        public void AgregarRolUsuarioExceptTest()
        {
            var UsuarioClient = new RolUsuario
            {
                UserId = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC192"),
                RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298162")
            };

            _contextMock.Setup(r => r.RolUsuarios.Add(UsuarioClient));

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            _contextMock.Setup(p => p.RolUsuarios).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.AgregarRol(UsuarioClient));
        }

    }
}
