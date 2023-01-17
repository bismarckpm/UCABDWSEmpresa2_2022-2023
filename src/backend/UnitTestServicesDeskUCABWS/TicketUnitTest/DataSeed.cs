using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using ServicesDeskUCABWS.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;

//Información Falsa creada con el fin de usarse en Pruebas Unitarias//

namespace TicketUnitTest
{
    public static class DataSeed
    {

        public static void SetupDbContextDataTicket(this Mock<IDataContext> _mockContext)
        {

            var ListaTicket = new List<Ticket>
            {

                new Ticket {
                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                titulo = "titulo",
                descripcion ="a",
                fecha_creacion = new DateTime(2008, 5, 1, 8, 30, 52),
                fecha_eliminacion = new DateTime(2008, 5, 1, 8, 30, 52),
                Departamento_Destino = new Departamento(){
                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),
                nombre = "nombre",
                descripcion = "descripcion",
                fecha_creacion = new DateTime(2008, 5, 1, 8, 30, 52)
},
                    Estado = new Estado(){
                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),
                    nombre = "nombre",
                    descripcion = "descripcion",
                    fecha_creacion = new DateTime(2008, 5, 1, 8, 30, 52),
                    fecha_ultima_edic = new DateTime(2008, 5, 1, 8, 30, 52) },
                    Prioridad =   new Prioridad(){
                    Id = new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650812"),
                    nombre ="nombre",
                    descripcion ="descripcion",
                    estado ="habilitado",
                    fecha_descripcion=new DateTime(2008, 5, 1, 8, 30, 52),
                    fecha_ultima_edic=new DateTime(2008, 5, 1, 8, 30, 52)
                },
                    Tipo_Ticket = new TipoTicket_FlujoNoAprobacion() {}
                    }


            };

            _mockContext.Setup(c => c.Tickets).Returns(ListaTicket.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Tickets.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaTicket.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Tickets.Add(It.IsAny<Ticket>())).Callback<Ticket>(ListaTicket.Add);
            _mockContext.Setup(set => set.Tickets.AddRange(It.IsAny<IEnumerable<Ticket>>())).Callback<IEnumerable<Ticket>>(ListaTicket.AddRange);
            _mockContext.Setup(set => set.Tickets.Add(It.IsAny<Ticket>()));
            _mockContext.Setup(e => e.Tickets.Update(It.IsAny<Ticket>()));

            List<Empleado> ListaEmpleado = new List<Empleado>
            {
                
            
                
              
            };
            _mockContext.Setup(c => c.Empleados).Returns(ListaEmpleado.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Empleados.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaEmpleado.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Empleados.Add(It.IsAny<Empleado>())).Callback<Empleado>(ListaEmpleado.Add);
            _mockContext.Setup(set => set.Empleados.AddRange(It.IsAny<IEnumerable<Empleado>>())).Callback<IEnumerable<Empleado>>(ListaEmpleado.AddRange);


        }




        public static void SetUpContextDataVacioTicket(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Ticket>() { };
            

            _mockContext.Setup(c => c.Tickets).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }


        public static void SetUpContextDataVacioEmpleado(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Empleado>() { };


            _mockContext.Setup(c => c.Empleados).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacioDeptartamento(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Departamento>() { };


            _mockContext.Setup(c => c.Departamentos).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }



        public static void SetUpContextDataVacioUsuario(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Usuario>() { };


            _mockContext.Setup(c => c.Usuarios).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacioEstado(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Estado>() { };


            _mockContext.Setup(c => c.Estados).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacioPrioridad(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Prioridad>() { };

            _mockContext.Setup(c => c.Prioridades).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacioVotos(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Votos_Ticket>() { };

            _mockContext.Setup(c => c.Votos_Tickets).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacioFamilia(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Familia_Ticket>() { };

            _mockContext.Setup(c => c.Familia_Tickets).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacioBitacora(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Bitacora_Ticket>() { };

            _mockContext.Setup(c => c.Bitacora_Tickets).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }

        public static void SetUpContextDataVacioTipo(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Tipo_Ticket>() { };

            _mockContext.Setup(c => c.Tipos_Tickets).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }


    }
}