using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ong.Domain.Command.Autenticacao.CreateToken
{
    public class CreateTokenCommand : IRequest<TokenResponse>
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
