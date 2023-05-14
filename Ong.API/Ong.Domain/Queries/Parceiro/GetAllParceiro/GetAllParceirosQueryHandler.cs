using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Infra.Data.Repositories;

namespace Ong.Domain.Queries.Parceiro.GetAllParceiro
{
    public class GetAllParceirosQueryHandler : IRequestHandler<GetAllParceirosQuery, GetAllParceirosQueryResponse>
    {
        private readonly ILogger _logger;
        private readonly IParceiroRepository _parceirosRepository;

        public GetAllParceirosQueryHandler(ILoggerFactory logger, IParceiroRepository parceirosRepository)
        {
            _logger = logger.CreateLogger<GetAllParceirosQueryHandler>();
            _parceirosRepository = parceirosRepository;
        }

        public async Task<GetAllParceirosQueryResponse> Handle(GetAllParceirosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllParceirosQueryHandler)}");
                var response = await _parceirosRepository.GetAllAsync();
                _logger.LogInformation($"Sucesso serviço {nameof(GetAllParceirosQueryHandler)}");

                return new GetAllParceirosQueryResponse(response);
            }
            catch (Exception)
            {
                _logger.LogError($"Erro serviço {nameof(GetAllParceirosQueryHandler)}");

                throw;
            }
        }
    }
}
