using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Controller
{
    public class UsuarioServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UsuarioServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetById(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var existUser = await GetById(id);

            if (existUser is not null)
            {
                _context.Usuarios.Remove(existUser);
                await _context.SaveChangesAsync();
            }
        }

    }
}
