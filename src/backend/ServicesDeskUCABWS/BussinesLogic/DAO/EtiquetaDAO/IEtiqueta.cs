using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.EtiquetaDAO
{
    public interface IEtiqueta
    {
        public Task<List<EtiquetaDTO>> ConsultaEtiquetas();
        public Task<EtiquetaDTO> ConsultarEtiquetaGUID(Guid id);
    }
}
