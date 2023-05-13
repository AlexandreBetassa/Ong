using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Interfaces
{
    public interface INoticiasRepository : IBaseRepository<Noticia>
    {
        Task<Noticia> GetByTitulo(string titulo);
    }
}
