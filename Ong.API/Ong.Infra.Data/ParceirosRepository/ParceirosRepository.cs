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

        public async Task<ParceirosOng> CreateAsync(ParceirosOng entity)
        {
            var result = await _context.Set<ParceirosOng>().AddAsync(entity);
            _context.SaveChanges();

            return result.Entity;
        }

        public async Task<ParceirosOng> DeleteAsync(ParceirosOng entity)
        {
            var result = _context.Set<ParceirosOng>().Remove(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<ParceirosOng>> GetAllAsync()
        {
            return await _context.Set<ParceirosOng>().ToListAsync();
        }

        public async Task<ParceirosOng> GetByIdAsync(int id)
        {
            return await _context
                            .Set<ParceirosOng>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(parceiro => parceiro.Id == id);
        }

        public async Task<ParceirosOng> GetParceiroByName(string name)
        {
            return await _context
                            .Set<ParceirosOng>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(parceiro => parceiro.Nome == name);
        }

        public async Task<ParceirosOng> UpdateAsync(ParceirosOng entity)
        {
            var result = _context.Set<ParceirosOng>().Update(entity);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}
