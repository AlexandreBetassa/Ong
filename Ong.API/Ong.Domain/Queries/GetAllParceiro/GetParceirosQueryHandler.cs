using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Infra.Data.Repositories;

namespace Ong.Domain.Queries.GetAllParceiro
{
    public class GetParceirosQueryHandler : IRequestHandler<GetParceirosQuery, GetParceirosQueryResponse>
    {
        private readonly ILogger _logger;
        private readonly IParceiroRepository _parceirosRepository;

        public GetParceirosQueryHandler(ILoggerFactory logger, IParceiroRepository parceirosRepository)
        {
            _logger = logger.CreateLogger<GetParceirosQueryHandler>();
            _parceirosRepository = parceirosRepository;
        }

        public async Task<GetParceirosQueryResponse> Handle(GetParceirosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetParceirosQueryHandler)}");
                var response = await _parceirosRepository.GetAllAsync();
                _logger.LogInformation($"Sucesso serviço {nameof(GetParceirosQueryHandler)}");

                return new GetParceirosQueryResponse(response);
            }
            catch (Exception)
            {
                _logger.LogError($"Erro serviço {nameof(GetParceirosQueryHandler)}");

                throw;
            }
        }
    }
}
