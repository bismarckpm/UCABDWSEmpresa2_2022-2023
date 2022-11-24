using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Diagnostics;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoI.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.UnitTestUsuario
{
    [TestClass]
    public class UsuarioServiceTest
    {

        private readonly UsuarioDAO _userService;
        private readonly Mock<IDataContext> _contextMock;

        public UsuarioServiceTest()
        {
            _contextMock = new Mock<IDataContext>();
            _userService = new UsuarioDAO(_contextMock.Object);
            _contextMock.SetupDataContextUser();
        }

        [TestMethod(displayName: "Prueba unitaria exitosa para consultar usuario")]
        public void ConsultarUsurioUnitTest()
        {
            var result = _userService.ObtenerUsuarios();
            Assert.IsTrue(result.Count > 0);

        }
        [TestMethod(displayName: "Prueba unitaria para consultar usuario por ID ")]
        public void ConsultarUsurioByID()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");

            var result = _userService.consularUsuarioID(id);

            Assert.AreEqual(result.Id , id );
        }

        [TestMethod(displayName:"Prueba unitaria cuando no exista el  usuario  consultado por ID")]
        public void NoExisteUsuarioPorIDTest()
        {
            Assert.ThrowsException<ExceptionsControl>(() => _userService.consularUsuarioID(new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC122")));
        }

        [TestMethod(displayName: "Prueba unitaria  para exception en consulta de usuarios")]
        public void consultaUsuarioException()

        {
            _contextMock.Setup(p => p.Usuarios).Throws(new Exception());

            Assert.ThrowsException<ExceptionsControl>(() => _userService.ObtenerUsuarios());
        }

        [TestMethod(displayName: "Prueba unitaria para agregar un Administrador")]
        public void AgregarAdmin()
            
        {
           
            var requestUserAdmin = new Usuario
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'M',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            _contextMock.Setup(r => r.Usuarios.Add(requestUserAdmin));

            var UsuarioClient = new RolUsuario
            {
                UserId = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298162")
            };

            _contextMock.Setup(r => r.RolUsuarios.Add(UsuarioClient));

            _contextMock.Setup(set => set.DbContext.SaveChanges());

           
            var usuario = _userService.AgregarAdminstrador(requestUserAdmin);

            Assert.AreEqual(usuario.Id, requestUserAdmin.Id);

        }
        [TestMethod(displayName: "Prueba unitaria para agregar un Cliente")]
        public void AgregarCliente()

        {

            var requestUserAdmin = new Usuario
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'M',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            _contextMock.Setup(r => r.Usuarios.Add(requestUserAdmin));

            var UsuarioClient = new RolUsuario
            {
                UserId = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298161")
            };

            _contextMock.Setup(r => r.RolUsuarios.Add(UsuarioClient));

            _contextMock.Setup(set => set.DbContext.SaveChanges());


            var usuario = _userService.AgregarCliente(requestUserAdmin);

            Assert.AreEqual(usuario.Id, requestUserAdmin.Id);

        }
        [TestMethod(displayName: "Prueba unitaria para agregar un Empleado")]
        public void AgregarEmpleado()

        {

            var requestUserAdmin = new Usuario
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'M',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            _contextMock.Setup(r => r.Usuarios.Add(requestUserAdmin));

            var UsuarioClient = new RolUsuario
            {
                UserId = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                RolId = new Guid("8C8A156B-7383-4610-8539-30CCF7298163")
            };

            _contextMock.Setup(r => r.RolUsuarios.Add(UsuarioClient));

            _contextMock.Setup(set => set.DbContext.SaveChanges());


            var usuario = _userService.AgregarEmpleado(requestUserAdmin);

            Assert.AreEqual(usuario.Id, requestUserAdmin.Id);

        }
        [TestMethod(displayName: "Prueba unitaria para actualizar un usuario")]
        public void ActualizarUsuario()
        {
            var requestUserAdmin = new Usuario
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'M',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            _contextMock.Setup(c => c.Usuarios.Add(requestUserAdmin));
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var usuario = _userService.ActualizarUsuario(requestUserAdmin);

            Assert.AreEqual(usuario.correo, requestUserAdmin.correo);
        }

    }
}
