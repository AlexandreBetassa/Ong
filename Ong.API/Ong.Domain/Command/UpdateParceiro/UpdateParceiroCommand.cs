using MediatR;
using System.Net;

namespace Ong.Domain.Command.UpdateParceiro
{
    public class UpdateParceiroCommand : IRequest<HttpStatusCode>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
