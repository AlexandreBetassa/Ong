using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> FindUsuarioLogin(string username);
        Task<Usuario> FindUsuarioByCpf(string cpf);
    }
}
