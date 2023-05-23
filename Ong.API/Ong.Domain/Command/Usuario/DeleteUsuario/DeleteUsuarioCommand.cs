using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Usuario.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<ObjectResult>
    {
        public int IdPessoa { get; set; }
    }
}
