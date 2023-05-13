using Ong.Domain.Entities;
using Ong.Domain.Interfaces;
using Ong.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Repositories
{
    public class PessoaRepository : IPessoaReppository
    {
        public IBaseRepository<Pessoa> _db;

        public PessoaRepository(IBaseRepository<Pessoa> db)
        {
            _db = db;
        }

        public async Task<Pessoa> CreateAsync(Pessoa entity)
        {
            return await _db.CreateAsync(entity);
        }

        public async Task<Pessoa> DeleteAsync(Pessoa entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<Pessoa> UpdateAsync(Pessoa entity)
        {
            return await _db.UpdateAsync(entity);
        }
    }
}
