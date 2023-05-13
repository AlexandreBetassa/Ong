using MediatR;
using System.Net;

namespace Ong.Domain.Command.Parceiros.CreateParceiro
{
    public class CreateParceiroCommand : IRequest<HttpStatusCode>
    {
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
