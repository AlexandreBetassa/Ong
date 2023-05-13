using Ong.Domain.Entities;
using Ong.Domain.Interfaces;
using Ong.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioReppository
    {
        public IBaseRepository<Usuario> _db;

        public UsuarioRepository(IBaseRepository<Usuario> db)
        {
            _db = db;
        }

        public async Task<Usuario> CreateAsync(Usuario entity)
        {
            return await _db.CreateAsync(entity);
        }

        public async Task<Usuario> DeleteAsync(Usuario entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<Usuario> UpdateAsync(Usuario entity)
        {
            return await _db.UpdateAsync(entity);
        }
    }
}
