using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Autenticacao.CreateToken
{
    public class CreateTokenCommandHandler : BaseHandler<CreateTokenCommand, ObjectResult>
    {
        private readonly ILogger _logger;
        private readonly IGenerateToken _generateToken;

        public CreateTokenCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger, IGenerateToken generateToken) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<CreateTokenCommandHandler>(); 
            _generateToken = generateToken;
        }

        public override async Task<ObjectResult> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await UnityOfWork.UsuarioRepository.FindUsuarioLogin(request.Usuario);

                var token = _generateToken.GerarTokenJwt(usuario);

                return Create(200, token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
