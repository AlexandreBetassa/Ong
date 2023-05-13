using Ong.Domain.Entities;

namespace Ong.Domain.Interfaces
{
    public interface IParceirosRepository : IBaseRepository<ParceirosOng>
    {
        Task<ParceirosOng> GetParceiroByName(string name);
    }
}
