using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
                password= "qwertyuiop",
                fecha_creacion= DateTime.Now.Date,
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
            _mockContext.Setup(set => set.DbContext.SaveChanges());



        }
    }
}
