using Ong.Domain.Entities;

namespace Ong.Domain.Queries.Parceiro.GetAllParceiro
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