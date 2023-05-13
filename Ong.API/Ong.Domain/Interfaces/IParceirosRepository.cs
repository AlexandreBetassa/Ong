using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Interfaces
{
    public interface IParceirosRepository : IBaseRepository<ParceiroOng>
    {
        Task<ParceiroOng> GetParceiroByName(string name);
    }
}
