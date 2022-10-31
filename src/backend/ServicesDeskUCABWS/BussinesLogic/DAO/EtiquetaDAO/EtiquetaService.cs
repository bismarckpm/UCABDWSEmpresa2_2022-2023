using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ServicesDeskUCABWS.BussinessLogic.DAO.EtiquetaDAO
{
    public class EtiquetaService : IEtiqueta
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
