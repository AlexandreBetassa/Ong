using Ong.Domain.Command.Autenticacao.CreateToken;
using Ong.Domain.Entities;

namespace Ong.Domain.Interfaces.Services
{
    public interface IGenerateToken
    {
        TokenResponse GerarTokenJwt(Usuario user);
    }
}
