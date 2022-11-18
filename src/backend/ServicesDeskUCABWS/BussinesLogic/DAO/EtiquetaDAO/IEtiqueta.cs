using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO
{
    public interface IEtiqueta
    {
        public List<EtiquetaDTO> ConsultaEtiquetas();
        public EtiquetaDTO ConsultarEtiquetaGUID(Guid id);
    }
}
