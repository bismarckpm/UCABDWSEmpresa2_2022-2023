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
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;

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

               new Empleado(45678, "Jorge", "Perez", "Bosquejo", "20/12/1999", 'M', "jpbosquejo@gmail.com", "1234", "Valentino")
                {
                    Id = Guid.Parse("0F636FB4-7F04-4A2E-B2C2-359B99BE85D1"),
                  
                },


            };
            _mockContext.Setup(c => c.Empleados).Returns(ListaEmpleado.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Empleados.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaEmpleado.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Empleados.Add(It.IsAny<Empleado>())).Callback<Empleado>(ListaEmpleado.Add);
            _mockContext.Setup(set => set.Empleados.AddRange(It.IsAny<IEnumerable<Empleado>>())).Callback<IEnumerable<Empleado>>(ListaEmpleado.AddRange);


            var ListaTicketNuevoDTO = new List<TicketNuevoDTO>
            {

                new TicketNuevoDTO {

                titulo = "titulo",
                descripcion = "aaaaaaaa",
                empleado_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c70"),
                prioridad_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c60"),
                tipoTicket_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c50"),
                departamentoDestino_Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c40"),
                ticketPadre_Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c30")

}

};

            var ListaTipoTickets = new List<Tipo_Ticket>
            {
                new TipoTicket_FlujoNoAprobacion("Solicitud","Descripcion TT1", "Modelo_No_Aprobacion")
                {
                    Id=Guid.Parse("23F0FB1D-25B5-4DFE-A432-408D1D9F6633")

                },
                new TipoTicket_FlujoAprobacionParalelo("Solicitud2","Descripcion TT2", "Modelo_Paralelo",1,1)
                {
                    Id = Guid.Parse("F863DBA2-5093-4E89-917A-03B5F585B3E7"),

                },
                new TipoTicket_FlujoAprobacionJerarquico("Solicitud3","Descripcion TT3", "Modelo_Jerarquico",null,null)
                {
                    Id = Guid.Parse("39C1E9A1-9DDE-4F1A-8FBB-4D52D4E45A19")
                },
                new TipoTicket_FlujoAprobacionParalelo("Solicitud4","Descripcion TT4", "Modelo_Paralelo", 1, 2)
                {
                    Id = Guid.Parse("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E"),


                },

                new TipoTicket_FlujoAprobacionJerarquico("Solicitud5","Descripcion TT3", "Modelo_Jerarquico",null,null)
                {

                }
            };

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