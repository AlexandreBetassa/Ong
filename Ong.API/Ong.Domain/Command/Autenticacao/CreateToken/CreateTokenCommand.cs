using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Autenticacao.CreateToken
{
    public class CreateTokenCommand : IRequest<ObjectResult>
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
