using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;

namespace Ong.Domain.Queries.Noticia.GetAllNoticia
{
    public class GetAllNoticiasQueryHandler : IRequestHandler<GetAllNoticiasQuery, GetAllNoticiasResponse>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;

        public GetAllNoticiasQueryHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork)
        {
            _logger = loggerFactory.CreateLogger<GetAllNoticiasQueryHandler>();
            _unityOfWork = unityOfWork;
        }

        public async Task<GetAllNoticiasResponse> Handle(GetAllNoticiasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllNoticiasQueryHandler)}");

                var noticias = await _unityOfWork.NoticiaRepository.GetAllAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllNoticiasQueryHandler)}");

                return new GetAllNoticiasResponse(noticias);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Erro serviço {nameof(GetAllNoticiasQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
