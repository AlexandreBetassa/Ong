using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly IBaseData<Animal> _db;

        public AnimalRepository(IBaseData<Animal> db)
        {
            _db = db;
        }
        public async Task<Animal> CreateAsync(Animal entity)
        {
            return await _db.CreateAsync(entity);
        }

        public async Task<Animal> DeleteAsync(Animal entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<Animal> UpdateAsync(Animal entity)
        {
            return await _db.UpdateAsync(entity);
        }
    }
}
