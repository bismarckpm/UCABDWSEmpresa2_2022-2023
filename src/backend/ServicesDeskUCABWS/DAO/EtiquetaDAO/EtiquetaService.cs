using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Exceptions;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.EtiquetaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.DAO.EtiquetaDAO
{
    public class EtiquetaService : IEtiquetaDAO
    {
        private readonly DataContext _EtiquetaContext;
        private readonly IMapper _mapper;

        public EtiquetaService(DataContext etiquetaContext, IMapper mapper)
        {
            _EtiquetaContext = etiquetaContext;
            _mapper = mapper;
        }

        //GET: Servicio para consultar todas las etiquetas
        public List<EtiquetaDTO> ConsultaEtiquetas()
        {
            //var data = _EtiquetaContext.Etiquetas.Include(p => p.ListaEstadosrelacionados);
            var data = _EtiquetaContext.Etiquetas.AsNoTracking();
            var etiDTO = _mapper.Map<List<EtiquetaDTO>>(data);
            return etiDTO.ToList();
        }

        //GET: Servicio para consultar una plantilla notificacion en especifico

        public EtiquetaDTO ConsultarEtiquetaGUID(Guid id)
        {
            try
            {
                
                var data = _EtiquetaContext.Etiquetas.AsNoTracking().Where(p => p.Id == id).Single();
                var etiDTO = _mapper.Map<EtiquetaDTO>(data);
                return etiDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe la etiqueta con ese ID", ex);
            }

        }




    }
}
