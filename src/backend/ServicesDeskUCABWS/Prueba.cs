using Microsoft.Extensions.Hosting;
using ServicesDeskUCABWS.Data;
using System.Linq;

namespace ServicesDeskUCABWS
{
    class Prueba
    {
        DataContext contexto;

        public Prueba()
        {
        }

        public Prueba(DataContext contexto)
        {
            this.contexto = contexto;
        }
        public void Prueba1()
        {
            using (var context = new DataContext())
            {
                context.Departamentos.ToList();
            }
        }
    }
    
}