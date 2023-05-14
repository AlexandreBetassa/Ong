using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Queries.Usuario.GetAllUsuario
{
    public class GetAllUsuarioQueryHandler : IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioResponse>
    {
        private readonly ILogger _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public GetAllUsuarioQueryHandler(ILoggerFactory logger, IUsuarioRepository usuarioRepository)
        {
            _logger = logger.CreateLogger<GetAllUsuarioQueryHandler>();
            _usuarioRepository = usuarioRepository;
        }

        public async Task<GetAllUsuarioResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllUsuarioQueryHandler)}");
                var usuarios = await _usuarioRepository.GetAllUsuariosAsync();
                _logger.LogInformation($"Sucesso serviço {nameof(GetAllUsuarioQueryHandler)}");

                return new GetAllUsuarioResponse(usuarios);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Erro serviço {nameof(GetAllUsuarioQueryHandler)} || Mensagem Erro: {e.Message}");

                throw;
            }
        }
    }
}
