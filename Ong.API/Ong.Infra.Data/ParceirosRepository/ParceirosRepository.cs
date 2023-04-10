using Ong.Domain.Entities;
using Ong.Domain.Interfaces;
using Ong.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.BaseData
{
    public class ParceirosRepository : IParceirosRepository
    {
        public readonly AppDbContext _context;

        public ParceirosRepository()
        {
        }

        public Task<ParceirosOng> CreateAsync(ParceirosOng entity)
        {
            throw new NotImplementedException();
        }

        public Task<ParceirosOng> DeleteAsync(ParceirosOng entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParceirosOng>> GetAllAsync()
        {
            var parceiros = new List<ParceirosOng>();

            parceiros.Add(new ParceirosOng { Nome = "parceiro1", UrlLogotipo = "logotipo 1" });
            parceiros.Add(new ParceirosOng { Nome = "parceiro2", UrlLogotipo = "logotipo 2" });

            return parceiros;
            //return await _context.Set<ParceirosOng>().ToListAsync();
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
