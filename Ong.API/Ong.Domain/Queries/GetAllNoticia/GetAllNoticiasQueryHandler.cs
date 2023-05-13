using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Infra.Data.Repositories;

namespace Ong.Domain.Queries.GetAllNoticia
{
    public class GetAllNoticiasQueryHandler : IRequestHandler<GetAllNoticiasQuery, GetAllNoticiasResponse>
    {
        private readonly ILogger _logger;
        private readonly INoticiaRepository _noticiasRepository;

        public GetAllNoticiasQueryHandler(ILoggerFactory loggerFactory, INoticiaRepository noticiasRepository)
        {
            _logger = loggerFactory.CreateLogger<GetAllNoticiasQueryHandler>();
            _noticiasRepository = noticiasRepository;
        }

        public async Task<GetAllNoticiasResponse> Handle(GetAllNoticiasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllNoticiasQueryHandler)}");

                var noticias = await _noticiasRepository.GetAllAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllNoticiasQueryHandler)}");

                return new GetAllNoticiasResponse(noticias);
            }
            catch (Exception)
            {
                _logger.LogInformation($"Erro serviço {nameof(GetAllNoticiasQueryHandler)}");

                throw;
            }
        }
    }
}
