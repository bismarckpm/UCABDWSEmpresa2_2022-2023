using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Controller
{
    /*
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

        public async Task<Usuario> CreateC(UsuarioDto newUserDto)
        {
            Console.WriteLine(newUserDto);
            var Usuario = new Cliente
            {
                Id = new Guid(),
                cedula = newUserDto.cedula,
                primer_nombre = newUserDto.primer_nombre,
                primer_apellido = newUserDto.primer_apellido,
                segundo_nombre = newUserDto.segundo_nombre,
                segundo_apellido = newUserDto.segundo_apellido,
                fecha_nacimiento = newUserDto.fecha_nacimiento,
                gender = newUserDto.gender,
                correo = newUserDto.correo,
                password = newUserDto.password,
                fecha_creacion = newUserDto.fecha_creacion,
                fecha_eliminacion = newUserDto.fecha_eliminacion,
                fecha_ultima_edicion = newUserDto.fecha_ultima_edicion, 
            };

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();
            return Usuario;
        }

        public async Task<Usuario> CreateA(UsuarioDto newUserDto)
        {
            Console.WriteLine(newUserDto);
            var Usuario = new Administrador
            {
                Id = new Guid(),
                cedula = newUserDto.cedula,
                primer_nombre = newUserDto.primer_nombre,
                primer_apellido = newUserDto.primer_apellido,
                segundo_nombre = newUserDto.segundo_nombre,
                segundo_apellido = newUserDto.segundo_apellido,
                fecha_nacimiento = newUserDto.fecha_nacimiento,
                gender = newUserDto.gender,
                correo = newUserDto.correo,
                password = newUserDto.password,
                fecha_creacion = newUserDto.fecha_creacion,
                NumeroDeCuentasBloqueadas = 0
            };

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();
            return Usuario;
        }
        

    }*/
}
