using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado;
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
        private readonly IMapper mapper;

        public UsuarioServiceTest()
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
            _userService = new UsuarioDAO(_contextMock.Object,mapper);
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
        }
        [TestMethod(displayName: "Prueba Unitaria intentar eliminar un usuario que no existe")]
        public void EliminarUsuarioExeptionTest()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");
            _contextMock.Setup(p => p.Usuarios).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() =>  _userService.eliminarUsuario(id));

        }

        [TestMethod(displayName: "Prueba Unitaria para eliminar un usuario")]
        public void EliminarUsuarioCtrlExceptionTest()
        {
            var id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B");
            var obj = new UsuarioDto();
            var result = _userService.eliminarUsuario(id);
            Assert.IsInstanceOfType(obj, result.GetType());

        }

        [TestMethod(displayName: "Prueba Unitaria para recuperar clave")]
        public void RecuperarPassword()
        {
            string id = "gabrielojeda7@gmail.com";
            var response = _userService.RecuperarClave(id);
            Assert.AreEqual(response, "Correo enviado");

        }


        [TestMethod(displayName: "Prueba Unitaria para recuperar clave exception")]
        public void RecuperarPasswordException()
        {
            string id = "gabrielojeda72@gmail.com";
            _contextMock.Setup(p => p.Usuarios).Throws(new Exception("El correo no esta registrado"));
            Assert.ThrowsException<ExceptionsControl>(() =>  _userService.RecuperarClave(id));
        }

        [TestMethod(displayName: "Prueba Unitaria para un Administrador con correo repetido")]
        public void AgregarAdministradorException()
        {
            //arrange
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
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(p => p.Usuarios).Throws(new DbUpdateException(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.AgregarAdminstrador(requestUserAdmin));
        }


        [TestMethod(displayName: "Prueba Unitaria para un Administrador con un problema el registrar")]
        public void AgregarAdministradorExceptionGeneric()
        {
            //arrange
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
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(p => p.Usuarios).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.AgregarAdminstrador(requestUserAdmin));
        }

        [TestMethod(displayName: "Prueba Unitaria para un Cliente con correo repetido")]
        public void AgregarClienteException()
        {
            //arrange
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
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(p => p.Usuarios).Throws(new DbUpdateException(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.AgregarCliente(requestUserAdmin));
        }


        [TestMethod(displayName: "Prueba Unitaria para un Cliente con un problema el registrar")]
        public void AgregarClienteExceptionGeneric()
        {
            //arrange
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
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(p => p.Usuarios).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.AgregarCliente(requestUserAdmin));
        }


        [TestMethod(displayName: "Prueba Unitaria para un Empleado con correo repetido")]
        public void AgregarEmpleadoException()
        {
            //arrange
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
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(p => p.Usuarios).Throws(new DbUpdateException(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.AgregarEmpleado(requestUserAdmin));
        }


        [TestMethod(displayName: "Prueba Unitaria para un Empleado con un problema el registrar")]
        public void AgregarEmpleadoExceptionGeneric()
        {
            //arrange
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
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            _contextMock.Setup(p => p.Usuarios).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _userService.AgregarEmpleado(requestUserAdmin));
        }


        [TestMethod(displayName: "Prueba Unitaria para editar un Usuario")]
        public void ActualizarUsuarioTest()
        {
            //arrange
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

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _userService.ActualizarUsuario(requestUserAdmin);

            Assert.AreEqual(result.primer_nombre, "Gabriel");
        }

        /*[TestMethod(displayName: "Prueba Unitaria para logeo satisfactorio")]
        public void LoginTest()
        {

        }*/

        

    }
}
