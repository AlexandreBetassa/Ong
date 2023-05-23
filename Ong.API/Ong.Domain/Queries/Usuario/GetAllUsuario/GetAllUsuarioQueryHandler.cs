using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Queries.Usuario.GetAllUsuario
{
    public class GetAllUsuarioQueryHandler : BaseHandler<GetAllUsuarioQuery, ObjectResult>
    {
        private readonly ILogger _logger;

        public GetAllUsuarioQueryHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<GetAllUsuarioQueryHandler>();
        }

        public override async Task<ObjectResult> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllUsuarioQueryHandler)}");

                var usuarios = await UnityOfWork.UsuarioRepository.GetAllUsuariosAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllUsuarioQueryHandler)}");

                return Create(200, new GetAllUsuarioQueryResponse(usuarios));
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAllUsuarioQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
