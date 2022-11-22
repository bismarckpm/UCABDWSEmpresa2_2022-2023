using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.DataSeed
{
    public static class DataSeed
    {
        public static void SetUpContextData(this Mock<IDataContext> _mockContext)
        {
            var request = new List<PlantillaNotificacion>
            {
                new PlantillaNotificacion
                {
                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    Titulo = "Plantilla Aprobado",
                    Descripcion = "Hola @Usuario su @Ticket",
                    TipoEstadoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    TipoEstado = new Tipo_Estado()
                    {
                        Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                        nombre = "Aprobado",
                        descripcion = "Cuando se aprueba un ticket",
                        etiquetaTipoEstado = new HashSet<EtiquetaTipoEstado>
                        {
                            new EtiquetaTipoEstado
                            {
                                etiquetaID = new Guid("c76a9916-4cbb-434c-b88e-1fc8152eca8c"),
                                tipoEstadoID = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                                etiqueta = new Etiqueta
                                {
                                    Id = new Guid("c76a9916-4cbb-434c-b88e-1fc8152eca8c"),
                                    nombre = "@Usuario",
                                    descripcion = "hola"
                                }
                            }
                        },
                        permiso = true, 
                    }
                },
                new PlantillaNotificacion
                {
                    Id = new Guid("99f401c9-12aa-46bf-82a2-05ff65bb2c87"),
                    Titulo = "Plantilla Rechazado",
                    Descripcion = "Hola @Usuario su @Ticket",
                    TipoEstadoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),
                    TipoEstado = new Tipo_Estado()
                    {
                        Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),
                        nombre = "Rechazado",
                        descripcion = "Cuando se rechaza un ticket",
                        etiquetaTipoEstado = new HashSet<EtiquetaTipoEstado>
                        {
                            new EtiquetaTipoEstado
                            {
                                etiquetaID = new Guid("c76a9916-4cbb-434c-b88e-1fc8152eca8c"),
                                tipoEstadoID = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                                etiqueta = new Etiqueta
                                {
                                    Id = new Guid("c76a9916-4cbb-434c-b88e-1fc8152eca8c"),
                                    nombre = "@Usuario",
                                    descripcion = "hola"
                                }
                            }
                        },
                        permiso = false,
                    }
                },
            };

            var requestEtiqueta = new List<Etiqueta>
            {
                new Etiqueta
                {
                    Id = new Guid("c76a9916-4cbb-434c-b88e-1fc8152eca8c"),
                    nombre = "@Usuario",
                    descripcion = "hola"
                }
            };

            var requestEmpleado = new List<Empleado>
            {
                new Empleado
                {
                    Id = new Guid("18f401c9-12aa-460f-80a2-00ff05bb0c06"),
                    primer_nombre = "primerNombre",
                    primer_apellido = "primerApellido",
                    cedula = 51353,
                    Cargo = new Cargo()
                    {
                        Id = Guid.NewGuid(),
                        nombre_departamental = "nombreDepartamental"
                    }
                }
            };

            var requestCliente = new List<Cliente>();


            var requestTipoEstado = request.Select(q => q.TipoEstado).ToList();

            _mockContext.Setup(c => c.PlantillasNotificaciones).Returns(request.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Tipos_Estados).Returns(requestTipoEstado.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Etiquetas).Returns(requestEtiqueta.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Empleados).Returns(requestEmpleado.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Clientes).Returns(requestCliente.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(set => set.PlantillasNotificaciones.Add(It.IsAny<PlantillaNotificacion>()));
            _mockContext.Setup(e => e.PlantillasNotificaciones.Update(It.IsAny<PlantillaNotificacion>()));
            _mockContext.Setup(e => e.PlantillasNotificaciones.Remove(It.IsAny<PlantillaNotificacion>()));
            _mockContext.Setup(set => set.DbContext.SaveChanges());

            _mockContext.Setup(set => set.Tipos_Estados.Add(It.IsAny<Tipo_Estado>()));
            _mockContext.Setup(e => e.Tipos_Estados.Update(It.IsAny<Tipo_Estado>()));
            _mockContext.Setup(e => e.Tipos_Estados.Remove(It.IsAny<Tipo_Estado>()));
        }

        public static void SetUpContextDataCliente(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Cliente>
            {
                new Cliente
                {
                    Id = new Guid("10f000c0-00aa-000f-00a2-00ff05bb0c06"),
                    primer_nombre = "primerNombreCliente",
                    primer_apellido = "primerApellidoCliente",
                    cedula = 51353
                }
            };

            var requestEmpleado = new List<Empleado>();

            _mockContext.Setup(c => c.Clientes).Returns(request.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Empleados).Returns(requestEmpleado.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacio(this Mock<IDataContext> _mockContext)
        {
            var request = new List<PlantillaNotificacion>() { };

            _mockContext.Setup(c => c.PlantillasNotificaciones).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataEtiquetaVacio(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Etiqueta>() { };

            _mockContext.Setup(c => c.Etiquetas).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataTipoEstadoVacio(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Tipo_Estado>() { };

            _mockContext.Setup(c => c.Tipos_Estados).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

       
    }
}
