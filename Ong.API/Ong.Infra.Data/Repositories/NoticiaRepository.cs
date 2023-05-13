using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces;
using Ong.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Repositories
{
    public class NoticiaRepository : INoticiasRepository
    {
        private readonly AppDbContext _context;

        public NoticiaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Noticia> CreateAsync(Noticia entity)
        {
            var noticia = await _context.Set<Noticia>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return noticia.Entity;
        }

        public async Task<Noticia> DeleteAsync(Noticia entity)
        {
            var noticia = _context.Set<Noticia>().Remove(entity);
            await _context.SaveChangesAsync();

            return noticia.Entity;
        }

        public async Task<IEnumerable<Noticia>> GetAllAsync()
        {
            return await _context.Set<Noticia>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public Task<Noticia> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Noticia> GetByTitulo(string titulo)
        {
            return await _context.Set<Noticia>()
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(noticia => noticia.Titulo.Equals(titulo));
        }

        public Task<Noticia> UpdateAsync(Noticia entity)
        {
            throw new NotImplementedException();
        }
    }
}
