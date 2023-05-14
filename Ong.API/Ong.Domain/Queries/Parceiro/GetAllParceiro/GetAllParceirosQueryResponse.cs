using Ong.Domain.Entities;

namespace Ong.Domain.Queries.Parceiro.GetAllParceiro
{
    public class GetAllParceirosQueryResponse
    {

        public IEnumerable<ParceiroOng> parceiros { get; set; }

        public GetAllParceirosQueryResponse(IEnumerable<ParceiroOng> parceiros)
        {
            this.parceiros = parceiros;
        }
    }
}