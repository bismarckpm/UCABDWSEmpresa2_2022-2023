using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.EtiquetaDAO
{
    public interface IEtiqueta
    {
        public List<EtiquetaDTO> ConsultaEtiquetas();
        public EtiquetaDTO ConsultarEtiquetaGUID(Guid id);
    }
}
