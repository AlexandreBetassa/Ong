using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Repositories
{
    public class AdocaoRepository : IAdocaoRepository
    {
        private readonly IBaseData<Adocao> _db;

        public AdocaoRepository(IBaseData<Adocao> db)
        {
            _db = db;
        }
        public async Task<Adocao> CreateAsync(Adocao entity)
        {
            return await _db.CreateAsync(entity);
        }

        public Task<Adocao> DeleteAsync(Adocao entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Adocao>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<Adocao> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<Adocao> UpdateAsync(Adocao entity)
        {
            return await _db.UpdateAsync(entity);
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
