using MediatR;
using Ong.Domain.Entities;

namespace Ong.Domain.Command.CreateParceiro
{
    public class CreateParceiroCommand : IRequest<ParceirosOng>
    {
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
