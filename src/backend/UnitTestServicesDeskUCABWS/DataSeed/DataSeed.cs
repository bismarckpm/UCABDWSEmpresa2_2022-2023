using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using ServicesDeskUCABWS.Entities;

namespace UnitTest_GrupoE.DataSeed
{
    public static class DataSeed
    {
        public static void SetupDbContextData(this Mock<IDataContext> _mockContext)
        {
            var ListaTipoEstados = new List<Tipo_Estado>
            {
                new Tipo_Estado("Aprobado", "Tipo Estado prueba")
                {
                    Id=new Guid("A4D4417A-9A80-4EC2-B01E-02F57EB31144")
                },
                new Tipo_Estado("Rechazado","Tipo Estado prueba")
                {
                    Id=new Guid("3DD45003-3829-473B-92E5-03199E545C6C")
                },
                new Tipo_Estado("Pendiente","Tipo Estado prueba")
                {
                    Id=new Guid("C32DBA61-E192-4462-8BD2-C4376A4AE4FC")
                },
                new Tipo_Estado("Cancelado","Tipo Estado prueba")
                {
                    Id=new Guid("822D08E6-713D-4F03-A634-520693D31E96")
                },


            };


            //_mockContext.Tipos_Estados.AddRange(ListaTipoEstados);
            _mockContext.Setup(c => c.Tipo_Estados).Returns(ListaTipoEstados.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Tipo_Estados.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaTipoEstados.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Tipo_Estados.Add(It.IsAny<Tipo_Estado>())).Callback<Tipo_Estado>(ListaTipoEstados.Add);
            _mockContext.Setup(set => set.Tipo_Estados.AddRange(It.IsAny<IEnumerable<Tipo_Estado>>())).Callback<IEnumerable<Tipo_Estado>>(ListaTipoEstados.AddRange);
            //_mockContext.Setup(set => set.Tipo_Estados.ToList().Contains(It.IsAny<object>())).Returns((object input) => ListaTipoEstados.Contains(input));
            /*_mockContext.Setup(mr => mr.Tipo_Estados.Update(It.IsAny<Tipo_Estado >()))
                   .Callback((Tipo_Estado e) => {
                       _mockContext.Object.Tipo_Estados.Update(e);
                   });*/

            var ListaGrupo = new List<Grupo>()
            {
                new Grupo("Grupo1","Grupo1"),
                new Grupo("Grupo2","Grupo2"),
            };

            //_mockContext.Grupos.AddRange(ListaGrupo);
            _mockContext.Setup(c => c.Grupos).Returns(ListaGrupo.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Grupos.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaGrupo.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Grupos.Add(It.IsAny<Grupo>())).Callback<Grupo>(ListaGrupo.Add);
            _mockContext.Setup(set => set.Grupos.AddRange(It.IsAny<IEnumerable<Grupo>>())).Callback<IEnumerable<Grupo>>(ListaGrupo.AddRange);

            var ListaDepartamento = new List<Departamento>()
            {
                new Departamento("Departamento1", "Descripcion1")
                {
                    Id= new Guid("CCACD411-1B46-4117-AA84-73EA64DEAC87"),
                    Grupo=ListaGrupo[0]
                },
                new Departamento("Departamento2", "Descripcion2")
                {
                    Id= new Guid("19C117F4-9C2A-49B1-A633-969686E0B57E"),
                    Grupo=ListaGrupo[0]
                }
            };

            //_mockContext.Departamentos.AddRange(ListaDepartamento);
            _mockContext.Setup(c => c.Departamentos).Returns(ListaDepartamento.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Departamentos.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaDepartamento.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Departamentos.Add(It.IsAny<Departamento>())).Callback<Departamento>(ListaDepartamento.Add);
            _mockContext.Setup(set => set.Departamentos.AddRange(It.IsAny<IEnumerable<Departamento>>())).Callback<IEnumerable<Departamento>>(ListaDepartamento.AddRange);

            var ListaEstados = new List<Estado>()
            {
                new Estado("Aprobado D1", "Descripcion D1")
                {
                    Id=new Guid("B74DF138-BA05-45A8-B890-E424CA60210C"),
                    Estado_Padre=ListaTipoEstados[0],
                    Departamento=ListaDepartamento[0]
                },
                new Estado("Rechazado D1", "Descripcion D1")
                {
                    Id=new Guid("048DAD5C-17E9-4D85-A846-42CFCD3FC183"),
                    Estado_Padre=ListaTipoEstados[1],
                    Departamento=ListaDepartamento[0]
                },
                new Estado("Pendiente D1", "Descripcion D1")
                {
                    Id=new Guid("CD72EA9E-CEB4-45AC-B80F-C3545F172A02"),
                    Estado_Padre=ListaTipoEstados[2],
                    Departamento=ListaDepartamento[0]
                },
                new Estado("Cancelado D1", "Descripcion D1")
                {
                    Id=new Guid("F70ECD4B-0119-42C9-B47E-852FA9D22B52"),
                    Estado_Padre=ListaTipoEstados[3],
                    Departamento=ListaDepartamento[0]
                },

                new Estado("Aprobado D2", "Descripcion D1")
                {

                    Estado_Padre=ListaTipoEstados[0],
                    Departamento=ListaDepartamento[1]
                },
                new Estado("Rechazado D2", "Descripcion D1")
                {

                    Estado_Padre=ListaTipoEstados[1],
                    Departamento=ListaDepartamento[1]
                },
                new Estado("Pendiente D2", "Descripcion D1")
                {

                    Estado_Padre=ListaTipoEstados[2],
                    Departamento=ListaDepartamento[1]
                },
                new Estado("Cancelado D2", "Descripcion D1")
                {

                    Estado_Padre=ListaTipoEstados[3],
                    Departamento=ListaDepartamento[1]
                }
            };

            //_mockContext.Estados.AddRange(ListaEstados);
            _mockContext.Setup(c => c.Estados).Returns(ListaEstados.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Estados.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaEstados.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Estados.Add(It.IsAny<Estado>())).Callback<Estado>(ListaEstados.Add);
            _mockContext.Setup(set => set.Estados.AddRange(It.IsAny<IEnumerable<Estado>>())).Callback<IEnumerable<Estado>>(ListaEstados.AddRange);


            var ListaPrioridad = new List<Prioridad>
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
            _mockContext.Setup(c => c.Prioridades).Returns(ListaPrioridad.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Prioridades.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaPrioridad.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Prioridades.Add(It.IsAny<Prioridad>())).Callback<Prioridad>(ListaPrioridad.Add);
            _mockContext.Setup(set => set.Prioridades.AddRange(It.IsAny<IEnumerable<Prioridad>>())).Callback<IEnumerable<Prioridad>>(ListaPrioridad.AddRange);

            var ListaTipoCargo = new List<Tipo_Cargo>
            {
                new Tipo_Cargo("Jefe","descripcion C1", "Alta")
                {
                    Id=Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C")
                },
                new Tipo_Cargo("Gerente","descripcion C2", "Media")
                {
                    Id=Guid.Parse("24259113-437B-417F-9159-A8E27C34A871")
                },
                new Tipo_Cargo("Empleado","descripcion C3","Baja"),
                new Tipo_Cargo("Becario","descripcion C4","Esclavo"),
            };

            //_mockContext.Tipos_Cargos.AddRange(ListaTipoCargo);
            _mockContext.Setup(c => c.Tipos_Cargos).Returns(ListaTipoCargo.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Tipos_Cargos.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaTipoCargo.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Tipos_Cargos.Add(It.IsAny<Tipo_Cargo>())).Callback<Tipo_Cargo>(ListaTipoCargo.Add);
            _mockContext.Setup(set => set.Tipos_Cargos.AddRange(It.IsAny<IEnumerable<Tipo_Cargo>>())).Callback<IEnumerable<Tipo_Cargo>>(ListaTipoCargo.AddRange);

            var ListaCargo = new List<Cargo>
            {
                new Cargo("Jefe D1","Descripccion C1")
                {
                    Departamento = ListaDepartamento[0],
                    Tipo_Cargo = ListaTipoCargo[0]
                },
                new Cargo("Gerente D1","Descripccion C1")
                {
                    Departamento = ListaDepartamento[0],
                    Tipo_Cargo = ListaTipoCargo[1]
                },
                new Cargo("Empleado D1","Descripccion C1")
                {
                    Departamento = ListaDepartamento[0],
                    Tipo_Cargo = ListaTipoCargo[2]
                },
                new Cargo("Becario D1","Descripccion C1")
                {
                    Departamento = ListaDepartamento[0],
                    Tipo_Cargo = ListaTipoCargo[3]
                },


                new Cargo("Jefe D2","Descripccion C1")
                {
                    Departamento = ListaDepartamento[1],
                    Tipo_Cargo = ListaTipoCargo[0]
                },
                new Cargo("Gerente D2","Descripccion C1")
                {
                    Departamento = ListaDepartamento[1],
                    Tipo_Cargo = ListaTipoCargo[1]
                },
                new Cargo("Empleado D2","Descripccion C1")
                {
                    Departamento = ListaDepartamento[1],
                    Tipo_Cargo = ListaTipoCargo[2]
                },
                new Cargo("Becario D2","Descripccion C1")
                {
                    Departamento = ListaDepartamento[1],
                    Tipo_Cargo = ListaTipoCargo[3]
                }
            };

            //_mockContext.Cargos.AddRange(ListaCargo);
            _mockContext.Setup(c => c.Cargos).Returns(ListaCargo.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Cargos.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaCargo.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Tipos_Cargos.Add(It.IsAny<Tipo_Cargo>())).Callback<Tipo_Cargo>(ListaTipoCargo.Add);
            _mockContext.Setup(set => set.Tipos_Cargos.AddRange(It.IsAny<IEnumerable<Tipo_Cargo>>())).Callback<IEnumerable<Tipo_Cargo>>(ListaTipoCargo.AddRange);
            //_mockContext.Setup(mr => mr.Tipos_Cargos.Update(It.IsAny<int>(), It.IsAny<string>())).Verifiable();


            var ListaUsuario = new List<Usuario>
            {
                //Jefes D1
                new Empleado(123456, "Jose", "Vargas", "Rojas", DateTime.Parse("20/12/1999"), 'M', "jmvargas@gmail.com", "1234", "Maria")
                {
                    
                    Cargo=ListaCargo[0]
                },
                new Empleado(654321, "Jose2", "Vargas2", "Rojas2", DateTime.Parse("20/12/1999"), 'M', "jmvargas2@gmail.com", "1234", "Maria2")
                {
                    Cargo=ListaCargo[0]
                },
                //Gerentes D1
                new Empleado(12345, "Daniel", "Rojas", "Bonavista", DateTime.Parse("20/12/1999"), 'M', "drbonavista@gmail.com", "1234", "Jose")
                {
                    Id = Guid.Parse("C035D2FC-C0E2-4AE0-9568-4A3AC66BB81A"),
                    Cargo=ListaCargo[1]
                },
                new Empleado(54321, "Daniel2", "Rojas2", "Bonavista2", DateTime.Parse("20/12/1999"), 'M', "drbonavista2@gmail.com", "1234", "Jose2")
                {
                    Cargo=ListaCargo[1]
                },
                //Empleados D1
                new Empleado(98765, "Adriana", "Guerrero", "Hugo", DateTime.Parse("20/12/1999"), 'M', "aghugo@gmail.com", "1234", "Valentina")
                {
                    Cargo=ListaCargo[2]
                },
                new Empleado(56789, "Adriana2", "Guerrero2", "Hugo2", DateTime.Parse("20/12/1999"), 'M', "aghugo2@gmail.com", "1234", "Valentina2")
                {
                    Cargo=ListaCargo[2]
                },
                //Becarios D1
                new Empleado(45678, "Jorge", "Perez", "Bosquejo", DateTime.Parse("20/12/1999"), 'M', "jpbosquejo@gmail.com", "1234", "Valentino")
                {
                    Cargo=ListaCargo[3]
                },
                new Empleado(87654, "Jorge2", "Perez2", "Bosquejo2", DateTime.Parse("20/12/1999"), 'M', "jpbosquejo2@gmail.com", "1234", "Valentino2")
                {
                    Id= Guid.Parse("E40D0211-EA65-49BB-BAEE-E8A5F504F3B1"),
                    Cargo=ListaCargo[3]
                },
            };

            //_mockContext.Usuarios.AddRange(ListaUsuario);
            _mockContext.Setup(c => c.Usuarios).Returns(ListaUsuario.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Usuarios.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaUsuario.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Usuarios.Add(It.IsAny<Usuario>())).Callback<Usuario>(ListaUsuario.Add);
            _mockContext.Setup(set => set.Usuarios.AddRange(It.IsAny<IEnumerable<Usuario>>())).Callback<IEnumerable<Usuario>>(ListaUsuario.AddRange);


            var ListaTipoTickets = new List<Tipo_Ticket>
            {
                new Tipo_Ticket("Solicitud","Descripcion TT1", "Modelo_No_Aprobacion")
                {

                    Departamento= new List<Departamento>
                    {
                        ListaDepartamento[0],
                        ListaDepartamento[1]
                    }
                },
                new Tipo_Ticket("Solicitud2","Descripcion TT2", "Modelo_Paralelo",1,1)
                {
                    Id = Guid.Parse("F863DBA2-5093-4E89-917A-03B5F585B3E7"),
                    Departamento= new List<Departamento>
                    {
                        ListaDepartamento[0]
                    }
                },
                new Tipo_Ticket("Solicitud3","Descripcion TT3", "Modelo_Jerarquico",null,null)
                {
                    Departamento= new List<Departamento>
                    {
                        ListaDepartamento[0]
                    }
                },
                new Tipo_Ticket("Solicitud4","Descripcion TT4", "Modelo_Paralelo", null, null)
                {
                    Id = Guid.Parse("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E"),
                    Departamento= new List<Departamento>
                    {
                        ListaDepartamento[0]
                    }

                }
            };

            var ListaFlujoAprobacion = new List<Flujo_Aprobacion>
            {
                new Flujo_Aprobacion(ListaTipoTickets[1].Id,ListaTipoCargo[1].Id, null,null,null)
                {
                    Tipo_Ticket = ListaTipoTickets[1],
                    Tipo_Cargo = ListaTipoCargo[1]
                },
                new Flujo_Aprobacion(ListaTipoTickets[1].Id,ListaTipoCargo[2].Id, null,null,null)
                {
                    Tipo_Ticket = ListaTipoTickets[1],
                    Tipo_Cargo = ListaTipoCargo[2]
                },
                new Flujo_Aprobacion(ListaTipoTickets[1].Id,ListaTipoCargo[1].Id, 2,1,1)
                {
                    Tipo_Ticket = ListaTipoTickets[1],
                    Tipo_Cargo = ListaTipoCargo[1]
                },
                new Flujo_Aprobacion(ListaTipoTickets[1].Id,ListaTipoCargo[2].Id, 1,1,1)
                {
                    Tipo_Ticket = ListaTipoTickets[1],
                    Tipo_Cargo = ListaTipoCargo[2]
                },
                new Flujo_Aprobacion(ListaTipoTickets[3].Id,ListaTipoCargo[2].Id, null,null,null)
                {
                    Tipo_Ticket = ListaTipoTickets[3],
                    Tipo_Cargo = ListaTipoCargo[2]
                }
            };

            ListaTipoTickets[1].Flujo_Aprobacion.Add(ListaFlujoAprobacion[0]);
            ListaTipoTickets[1].Flujo_Aprobacion.Add(ListaFlujoAprobacion[1]);

            ListaTipoTickets[2].Flujo_Aprobacion.Add(ListaFlujoAprobacion[2]);
            ListaTipoTickets[2].Flujo_Aprobacion.Add(ListaFlujoAprobacion[3]);

            ListaTipoTickets[3].Flujo_Aprobacion.Add(ListaFlujoAprobacion[4]);
            //_mockContext.Tipos_Tickets.AddRange(ListaTipoTickets);
            //_mockContext.Flujos_Aprobaciones.AddRange(ListaFlujoAprobacion);
            _mockContext.Setup(c => c.Tipos_Tickets).Returns(ListaTipoTickets.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Tipos_Tickets.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaTipoTickets.Where(x => (Guid)x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Tipos_Tickets.Add(It.IsAny<Tipo_Ticket>())).Callback<Tipo_Ticket>(ListaTipoTickets.Add);
            _mockContext.Setup(set => set.Tipos_Tickets.AddRange(It.IsAny<IEnumerable<Tipo_Ticket>>())).Callback<IEnumerable<Tipo_Ticket>>(ListaTipoTickets.AddRange);

            _mockContext.Setup(c => c.Flujos_Aprobaciones).Returns(ListaFlujoAprobacion.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(set => set.Flujos_Aprobaciones.Add(It.IsAny<Flujo_Aprobacion>())).Callback<Flujo_Aprobacion>(ListaFlujoAprobacion.Add);
            _mockContext.Setup(set => set.Flujos_Aprobaciones.AddRange(It.IsAny<IEnumerable<Flujo_Aprobacion>>())).Callback<IEnumerable<Flujo_Aprobacion>>(ListaFlujoAprobacion.AddRange);

            var ListaTickets = new List<Ticket>
            {
                new Ticket("Peticion 1", "Descripcion de la peticion 1")
                {
                    Tipo_Ticket=ListaTipoTickets[1],
                    Emisor= (Empleado) ListaUsuario[6],
                    Departamento_Destino= ListaDepartamento[1],
                    Estado = ListaEstados[2],
                    Prioridad = ListaPrioridad[1]
                },

                new Ticket("Peticion 2", "Descripcion Peticion 2")
                {
                    Id = Guid.Parse("5992E4A2-4737-42FB-88E2-FBC37EF26751"),
                    Tipo_Ticket=ListaTipoTickets[2],
                    Emisor= (Empleado) ListaUsuario[7],
                    Departamento_Destino= ListaDepartamento[1],
                    Estado = ListaEstados[2],
                    Prioridad = ListaPrioridad[1],
                    nro_cargo_actual = 1
                },

                new Ticket("Prueba Votos", "Lorem Ipsum")
                {
                    Id = Guid.Parse("EC1DDF25-80AF-47AF-AA24-A5B159C5A90F"),
                    Tipo_Ticket=ListaTipoTickets[2],
                    Emisor= (Empleado) ListaUsuario[7],
                    Departamento_Destino= ListaDepartamento[1],
                    Estado = ListaEstados[2],
                    Prioridad = ListaPrioridad[1],
                    nro_cargo_actual = 1
                }
            };

            var ListaVotos = new List<Votos_Ticket>
            {

                //Votos 1er Ticket
                new Votos_Ticket()
                {
                    Ticket = ListaTickets[0],
                    Empleado = (Empleado) ListaUsuario[0],
                    IdTicket = ListaTickets[0].Id,
                    IdUsuario = ListaUsuario[0].Id,
                    voto = "Pendiente"
                },
                new Votos_Ticket()
                {
                    Ticket = ListaTickets[0],
                    Empleado = (Empleado) ListaUsuario[1],
                    IdTicket = ListaTickets[0].Id,
                    IdUsuario = ListaUsuario[1].Id,
                    voto = "Pendiente"
                },
                new Votos_Ticket()
                {
                    Ticket = ListaTickets[0],
                    Empleado = (Empleado) ListaUsuario[2],
                    IdTicket = ListaTickets[0].Id,
                    IdUsuario = ListaUsuario[2].Id,
                    voto = "Pendiente"
                },
                new Votos_Ticket()
                {
                    Ticket = ListaTickets[0],
                    Empleado = (Empleado) ListaUsuario[3],
                    IdTicket = ListaTickets[0].Id,
                    IdUsuario = ListaUsuario[3].Id,
                    voto = "Pendiente"
                },

                //Votos 2do Ticket
                new Votos_Ticket()
                {
                    Ticket = ListaTickets[1],
                    Empleado = (Empleado) ListaUsuario[2],
                    IdTicket = ListaTickets[1].Id,
                    IdUsuario = ListaUsuario[2].Id,
                    voto = "Pendiente",
                    Turno = 1
                },
                new Votos_Ticket()
                {
                    Ticket = ListaTickets[1],
                    Empleado = (Empleado) ListaUsuario[3],
                    IdTicket = ListaTickets[1].Id,
                    IdUsuario = ListaUsuario[3].Id,
                    voto = "Pendiente",
                    Turno = 1
                },
            };

            //_mockContext.Tickets.AddRange(ListaTickets);
            //_mockContext.Votos_Tickets.AddRange(ListaVotos);
            _mockContext.Setup(c => c.Tickets).Returns(ListaTickets.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Tickets.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaTickets.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Tickets.Add(It.IsAny<Ticket>())).Callback<Ticket>(ListaTickets.Add);
            _mockContext.Setup(set => set.Tickets.AddRange(It.IsAny<IEnumerable<Ticket>>())).Callback<IEnumerable<Ticket>>(ListaTickets.AddRange);

            _mockContext.Setup(c => c.Votos_Tickets).Returns(ListaVotos.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(set => set.Votos_Tickets.Add(It.IsAny<Votos_Ticket>())).Callback<Votos_Ticket>(ListaVotos.Add);
            _mockContext.Setup(set => set.Votos_Tickets.AddRange(It.IsAny<IEnumerable<Votos_Ticket>>())).Callback<IEnumerable<Votos_Ticket>>(ListaVotos.AddRange);
        }
    }
}
