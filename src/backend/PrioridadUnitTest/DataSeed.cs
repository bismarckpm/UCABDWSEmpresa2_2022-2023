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

namespace PrioridadUnitTest
{
    public static class DataSeed
    {
        public static void SetupDbContextData(this Mock<IDataContext> _mockContext)
        {

            /*var ListaPrioridad = new List<Prioridad>
            {
                new Prioridad("Urgente","Descripcion P1")
                {
                    Id= Guid.Parse("2DF5B096-DC5A-421F-B109-2A1D1E650807")
                },
                new Prioridad("Alta","Descripcion P2"),
                new Prioridad("Media","Descripcion P3"),
                new Prioridad("Baja","Descripcion P4"),

            };

            //_mockContext.Prioridades.AddRange(ListaPrioridad);
            _mockContext.Setup(c => c.Prioridad).Returns(ListaPrioridad.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Prioridad.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaPrioridad.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Prioridad.Add(It.IsAny<Prioridad>())).Callback<Prioridad>(ListaPrioridad.Add);
            _mockContext.Setup(set => set.Prioridad.AddRange(It.IsAny<IEnumerable<Prioridad>>())).Callback<IEnumerable<Prioridad>>(ListaPrioridad.AddRange);
            */



        }

    }
}
