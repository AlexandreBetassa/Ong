using AutoMapper.Internal;
using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Data.BaseData
{
    public class OngRepository<T> : IBaseData<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public OngRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var noticia = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return noticia.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            {
                var noticia = _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

                return noticia.Entity;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Set<Usuario>()
                                 .Include(x => x.Endereco)
                                 .Include(x => x.Contato)
                                 .Include(x => x.authentication)
                                 .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var noticia = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return noticia.Entity;
        }
    }
}
