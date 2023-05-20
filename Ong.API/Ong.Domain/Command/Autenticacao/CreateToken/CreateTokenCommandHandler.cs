using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Noticias.CreateNoticia;
using Ong.Domain.Interfaces;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;

namespace Ong.Domain.Command.Autenticacao.CreateToken
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, TokenResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IGenerateToken _generateToken;
        private readonly IUnityOfWork _unityOfWork;

        public CreateTokenCommandHandler
            (ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork, IGenerateToken generateToken)
        {
            _logger = loggerFactory.CreateLogger<CreateNoticiaCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _generateToken = generateToken;
        }

        public async Task<TokenResponse> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _unityOfWork.UsuarioRepository.FindUsuarioLogin(request.Usuario);

                var token = _generateToken.GerarTokenJwt(usuario);

                return token;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
