using MediatR;
using System.Net;

namespace Ong.Domain.Command.Adocao.CreateAdocao
{
    public class CreateAdocaoCommand : IRequest<HttpStatusCode>
    {
        public string CpfCandidato { get; set; }
        public int IdAnimal { get; set; }
    }
}
