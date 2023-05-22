using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Queries.Usuario.GetAllUsuario
{
    public class GetAllUsuarioQueryHandler : IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;

        public GetAllUsuarioQueryHandler(ILoggerFactory logger, IUnityOfWork unityOfWork)
        {
            _logger = logger.CreateLogger<GetAllUsuarioQueryHandler>();
            _unityOfWork = unityOfWork;
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllUsuarioQueryHandler)}");

                var usuarios = await _unityOfWork.UsuarioRepository.GetAllUsuariosAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllUsuarioQueryHandler)}");

                return new GetAllUsuarioQueryResponse(usuarios);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAllUsuarioQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
