using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesGenerales
{
    public class ValidacionesGenerales<T> where T : class
    {
        public bool ListaTieneElementos(List<T> lista)
        {
            if(lista.Count == 0)
            { 
                return false;
            }
            else
            {
                return true;
            }
                
        }
    }
}
