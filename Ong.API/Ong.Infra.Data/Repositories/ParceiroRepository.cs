using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Repositories
{
    public class ParceiroRepository : IParceiroRepository
    {
        private readonly IBaseData<ParceiroOng> _db;
        public ParceiroRepository(IBaseData<ParceiroOng> db)
        {
            _db = db;
        }

        public async Task<ParceiroOng> CreateAsync(ParceiroOng entity)
        {
            return await _db.CreateAsync(entity);
        }

        public async Task<ParceiroOng> DeleteAsync(ParceiroOng entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<IEnumerable<ParceiroOng>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<ParceiroOng> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<ParceiroOng> UpdateAsync(ParceiroOng entity)
        {
            return await _db.UpdateAsync(entity);
        }
    }
}
