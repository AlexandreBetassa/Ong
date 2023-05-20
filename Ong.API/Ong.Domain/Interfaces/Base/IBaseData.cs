using Ong.Domain.Entities;

namespace Ong.Domain.Interfaces.Base
{
    public interface IBaseData<T> where T : class
    {
        abstract Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> FindUsuarioLogin(string usuario);
        Task<Usuario> FindByCpf(string cpf);
        Task SaveChangesAsync();
    }
}
