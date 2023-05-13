using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces;
using Ong.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.BaseData
{
    public class ParceirosRepository : IParceirosRepository
    {
        public readonly AppDbContext _context;

        public ParceirosRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ParceiroOng> CreateAsync(ParceiroOng entity)
        {
            var result = await _context.Set<ParceiroOng>().AddAsync(entity);
            _context.SaveChanges();

            return result.Entity;
        }

        public async Task<ParceiroOng> DeleteAsync(ParceiroOng entity)
        {
            var result = _context.Set<ParceiroOng>().Remove(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<ParceiroOng>> GetAllAsync()
        {
            return await _context.Set<ParceiroOng>().ToListAsync();
        }

        public async Task<ParceiroOng> GetByIdAsync(int id)
        {
            return await _context
                            .Set<ParceiroOng>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(parceiro => parceiro.Id == id);
        }

        public async Task<ParceiroOng> GetParceiroByName(string name)
        {
            return await _context
                            .Set<ParceiroOng>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(parceiro => parceiro.Nome == name);
        }

        public async Task<ParceiroOng> UpdateAsync(ParceiroOng entity)
        {
            var result = _context.Set<ParceiroOng>().Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
