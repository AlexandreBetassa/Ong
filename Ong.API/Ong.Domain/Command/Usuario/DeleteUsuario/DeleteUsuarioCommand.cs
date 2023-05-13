using MediatR;
using System.Net;

namespace Ong.Domain.Command.Usuario.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<HttpStatusCode>
    {
        public int IdPessoa { get; set; }
    }
}
