using Ong.Domain.Entities;

namespace Ong.Domain.Queries.GetAllParceiro
{
    public class GetParceirosQueryResponse
    {

        public IEnumerable<ParceiroOng> parceiros { get; set; }

        public GetParceirosQueryResponse(IEnumerable<ParceiroOng> parceiros)
        {
            this.parceiros = parceiros;
        }
    }
}