using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.EtiquetaDTO;
using ServicesDeskUCABWS.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.DAO.EtiquetaDAO
{
    public interface IEtiquetaDAO
    {
        public List<EtiquetaDTO> ConsultaEtiquetas();

        public EtiquetaDTO ConsultarEtiquetaGUID(Guid id);
    }
}
