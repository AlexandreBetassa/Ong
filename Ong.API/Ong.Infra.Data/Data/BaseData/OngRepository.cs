using Microsoft.EntityFrameworkCore;
using Ong.Domain.Entities;
using Ong.Domain.Entities.Base;
using Ong.Domain.Interfaces.Base;
using Ong.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ong.Infra.Data.Data.BaseData
{
    public class OngRepository<T> : IBaseData<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public OngRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var noticia = await _context.Set<T>()
                                        .AddAsync(entity);

            return noticia.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            {
                var noticia = _context.Set<T>().Remove(entity);

                return noticia.Entity;
            }
        }

        public async Task<Usuario> FindByCpf(string cpf)
        {
            return await _context.Set<Usuario>()
                                 .Include(usuario => usuario.Endereco)
                                 .Include(usuario => usuario.Contato)
                                 .FirstOrDefaultAsync(usuario => usuario.Cpf.Equals(cpf));

        }

        public async Task<Usuario> FindUsuarioLogin(string usuario)
        {
            return await _context.Set<Usuario>()
                                 .Include(x => x.Authentication)
                                 .FirstOrDefaultAsync(x => x.Authentication.EmailUsuario.Equals(usuario)
                                                        || x.Authentication.NomeUsuario.Equals(usuario));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Set<Usuario>()
                                 .Include(x => x.Endereco)
                                 .Include(x => x.Contato)
                                 .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                                 .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var noticia = _context.Set<T>().Update(entity);

            return noticia.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
