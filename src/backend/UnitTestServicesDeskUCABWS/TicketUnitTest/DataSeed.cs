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
                    Tipo_Ticket = new Tipo_Ticket() {}
                    }


            };

            _mockContext.Setup(c => c.Tickets).Returns(ListaTicket.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Tickets.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaTicket.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Tickets.Add(It.IsAny<Ticket>())).Callback<Ticket>(ListaTicket.Add);
            _mockContext.Setup(set => set.Tickets.AddRange(It.IsAny<IEnumerable<Ticket>>())).Callback<IEnumerable<Ticket>>(ListaTicket.AddRange);
            _mockContext.Setup(set => set.Tickets.Add(It.IsAny<Ticket>()));
            _mockContext.Setup(e => e.Tickets.Update(It.IsAny<Ticket>()));



        }

        


        public static void SetUpContextDataVacio(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Ticket>() { };

            _mockContext.Setup(c => c.Tickets).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }




       


    }
}