using Ong.Domain.Entities;

namespace Ong.Domain.Queries
{
    public class GetParceirosResponse
    {

        public IEnumerable<ParceirosOng> parceiros { get; set; }

        public GetParceirosResponse(IEnumerable<ParceirosOng> parceiros)
        {
            this.parceiros = parceiros;
        }
    }
}