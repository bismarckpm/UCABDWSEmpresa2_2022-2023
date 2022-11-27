using Microsoft.Extensions.Options;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.Tools;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoI.DataSeed
{
    public static class DataSeed
    {

        public static void SetupDataContextUser(this Mock<IDataContext> _mockContext)

        {


            var adminRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298162"), Name = "Administrador" };

            var emplRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298163"), Name = "Empleado" };

            var clientRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298161"), Name = "Cliente" };



            var requestUserAdmin = new Administrador
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            var requestRoleAdmin = new RolUsuario
            {
                User = requestUserAdmin,
                UserId = requestUserAdmin.Id,
                RolId = adminRol.Id,
                Rol = adminRol
            };

            var RequestUser = new Usuario
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            var requestListUser = new List<Usuario>
            {
                    new Usuario
                {
                    Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                    cedula = 12345,
                    primer_nombre = "Gabriel",
                    segundo_nombre = "David",
                    primer_apellido = "Ojeda",
                    segundo_apellido = "Cruz",
                    fecha_nacimiento = "21/12/2020",
                    gender = 'm',
                    correo = "gabrielojeda7@gmail.com",
                    password= "qwertyuiop",
                    fecha_creacion= DateTime.Now.Date,
                    fecha_ultima_edicion = default(DateTime),
                    fecha_eliminacion = default(DateTime),
                },
                new Usuario
                {
                    Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC199"),
                    cedula = 12345,
                    primer_nombre = "Gabriel",
                    segundo_nombre = "David",
                    primer_apellido = "Ojeda",
                    segundo_apellido = "Cruz",
                    fecha_nacimiento = "21/12/2020",
                    gender = 'm',
                    correo = "gabrielojeda@gmail.com",
                    password = "qwertyuiop",
                    fecha_creacion = DateTime.Now.Date,
                    fecha_ultima_edicion = default(DateTime),
                    fecha_eliminacion = default(DateTime),
                },


        };
            var requestRoleListAdmin1 = new RolUsuario
            {
                User = requestListUser[0],
                UserId = requestListUser[0].Id,
                RolId = adminRol.Id,
                Rol = adminRol
            };

            var requestRoleListAdmin = new RolUsuario
            {
                User = requestListUser[1],
                UserId = requestListUser[1].Id,
                RolId = adminRol.Id,
                Rol = adminRol
            };


            _mockContext.Setup(c => c.Usuarios).Returns(requestListUser.AsQueryable().BuildMockDbSet().Object);

            //_mockContext.Setup(c => c.RolUsuarios.Add(It.IsAny<RolUsuario>()));

            _mockContext.Setup(c => c.Administradores.Add(It.IsAny<Administrador>()));
            _mockContext.Setup(c => c.Administradores.Update(It.IsAny<Administrador>()));
            _mockContext.Setup(c => c.Usuarios.Add(It.IsAny<Usuario>()));
            _mockContext.Setup(c => c.RolUsuarios.Add(It.IsAny<RolUsuario>()));
            _mockContext.Setup(c => c.Empleados.Add(It.IsAny<Empleado>()));
            _mockContext.Setup(set => set.DbContext.SaveChanges());



        }

        public static void SetupDataContextRolUser(this Mock<IDataContext> _mockContext)

        {
            var adminRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298162"), Name = "Administrador" };

            var emplRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298163"), Name = "Empleado" };

            var clientRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298161"), Name = "Cliente" };



            var requestUserAdmin = new Administrador
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                cedula = 12345,
                primer_nombre = "Gabriel",
                segundo_nombre = "David",
                primer_apellido = "Ojeda",
                segundo_apellido = "Cruz",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            var requestUserAdmin2 = new Administrador
            {
                Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC192"),
                cedula = 12345,
                primer_nombre = "Diego",
                segundo_nombre = "Alejandro",
                primer_apellido = "Cumares",
                segundo_apellido = "Velasquez",
                fecha_nacimiento = "21/12/2020",
                gender = 'm',
                correo = "gabrielojeda7@gmail.com",
                password = "qwertyuiop",
                fecha_creacion = DateTime.Now.Date,
                fecha_ultima_edicion = default(DateTime),
                fecha_eliminacion = default(DateTime),
            };

            var requestRoleAdmin = new List<RolUsuario>
            {
                new RolUsuario
                    {
                        User = requestUserAdmin,
                        UserId = requestUserAdmin.Id,
                        RolId = adminRol.Id,
                        Rol = adminRol
                    },
            };

            _mockContext.Setup(c => c.RolUsuarios).Returns(requestRoleAdmin.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Administradores.Add(It.IsAny<Administrador>()));
            _mockContext.Setup(c => c.RolUsuarios.Add(It.IsAny<RolUsuario>()));
            _mockContext.Setup(set => set.DbContext.SaveChanges());

        }


        public static void SetupDataContextLoginUser(this Mock<IDataContext> _mockContext)

        {
            var listRol = new List<Rol>
            {
                new Rol {
                    Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298162"), Name = "Administrador"
                }
            };
            //var adminRol = new Rol { };

            //var emplRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298163"), Name = "Empleado" };

            //var clientRol = new Rol { Id = Guid.Parse("8C8A156B-7383-4610-8539-30CCF7298161"), Name = "Cliente" };

            var RequestUsers = new List<Usuario>
            {
                 new Usuario
                {
                    Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC19B"),
                    cedula = 12345,
                    primer_nombre = "Gabriel",
                    segundo_nombre = "David",
                    primer_apellido = "Ojeda",
                    segundo_apellido = "Cruz",
                    fecha_nacimiento = "21/12/2020",
                    gender = 'm',
                    correo = "gabrielojeda7@gmail.com",
                    password = "qwertyuiop",
                    fecha_creacion = DateTime.Now.Date,
                    fecha_ultima_edicion = default(DateTime),
                    fecha_eliminacion = default(DateTime),
                },
                 new Usuario
                {
                    Id = new Guid("69C30E04-4EB1-4B87-9F32-67DAC2FDC112"),
                    cedula = 12345,
                    primer_nombre = "Gabriel",
                    segundo_nombre = "David",
                    primer_apellido = "Ojeda",
                    segundo_apellido = "Cruz",
                    fecha_nacimiento = "21/12/2020",
                    gender = 'm',
                    correo = "gabrielojeda3@gmail.com",
                    password = "qwertyuiop",
                    fecha_creacion = DateTime.Now.Date,
                    fecha_ultima_edicion = default(DateTime),
                    fecha_eliminacion = default(DateTime),
                }
            }
            ;
            var requestRoleAdmin = new List<RolUsuario>
            {
                new RolUsuario
                    {
                        User = RequestUsers[0],
                        UserId = RequestUsers[0].Id,
                        RolId = listRol[0].Id,
                        Rol = listRol[0]
                    },
            };

            _mockContext.Setup(c => c.RolUsuarios).Returns(requestRoleAdmin.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Usuarios.Add(It.IsAny<Usuario>()));
            _mockContext.Setup(c => c.RolUsuarios.Add(It.IsAny<RolUsuario>()));
            _mockContext.Setup(c => c.Usuarios).Returns(RequestUsers.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Roles).Returns(listRol.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Roles.Add(It.IsAny<Rol>()));

            _mockContext.Setup(set => set.DbContext.SaveChanges());
        }
    }
}
