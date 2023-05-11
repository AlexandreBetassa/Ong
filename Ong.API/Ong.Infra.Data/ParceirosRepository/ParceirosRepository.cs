using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces;
using Ong.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<ParceirosOng> DeleteAsync(ParceirosOng entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParceirosOng>> GetAllAsync()
        {
            return await _context.Set<ParceirosOng>().ToListAsync();
        }

        public Task<ParceirosOng> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ParceirosOng> UpdateAsync(ParceirosOng entity)
        {
            throw new NotImplementedException();
        }
    }
}
