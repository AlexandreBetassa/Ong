using MediatR;
using System.Net;

namespace Ong.Domain.Command.Pessoa.DeletePessoa
{
    public class DeletePessoaCommand : IRequest<HttpStatusCode>
    {
        public int IdPessoa { get; set; }
    }
}
