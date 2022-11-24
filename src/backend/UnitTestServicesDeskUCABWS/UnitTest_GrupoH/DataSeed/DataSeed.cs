using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MockQueryable.Moq;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.DataSeed
{
    public static class DataSeed
    {
        public static void SetUpContextDataDepartamento(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Departamento>
            {
                new Departamento
                {  
                    id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                    nombre = "Seguridad Ambiental",

                    descripcion = "Cuida el ambiente",

                    fecha_creacion = DateTime.Now.Date,

                    fecha_ultima_edicion = null,

                    fecha_eliminacion = null,

                    id_grupo = null

                }              

            };

            _mockContext.Setup(c => c.Departamentos).Returns(request.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(set => set.Departamentos.Add(It.IsAny<Departamento>()));
            _mockContext.Setup(e => e.Departamentos.Update(It.IsAny<Departamento>()));
            _mockContext.Setup(e => e.Departamentos.Remove(It.IsAny<Departamento>()));
            _mockContext.Setup(set => set.DbContext.SaveChanges());
        }
        
        
    }
}
