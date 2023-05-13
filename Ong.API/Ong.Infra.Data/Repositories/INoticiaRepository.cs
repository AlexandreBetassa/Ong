using Ong.Domain.Entities;
using Ong.Infra.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Domain.Interfaces.Base
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly IBaseRepository<Noticia> _db;

        public NoticiaRepository(IBaseRepository<Noticia> db)
        {
            _db = db;
        }

        public async Task<Noticia> CreateAsync(Noticia entity)
        {
            return await _db.CreateAsync(entity);
        }

        public async Task<Noticia> DeleteAsync(Noticia entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Noticia>> GetAllAsync()
        {
            return await _db.GetAllAsync();
        }

        public async Task<Noticia> GetByIdAsync(int id)
        {
            return await _db.GetByIdAsync(id);
        }

        public async Task<Noticia> UpdateAsync(Noticia entity)
        {
            return await _db.UpdateAsync(entity);
        }
    }
}
