using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Queries
{
    public class GetParceirosQueryCommandHandler : IRequestHandler<GetParceirosQueryCommand, GetParceirosResponse>
    {
        private readonly ILogger _logger;
        private readonly IParceirosRepository _parceirosRepository;

        public GetParceirosQueryCommandHandler(ILoggerFactory logger, IParceirosRepository parceirosRepository)
        {
            _logger = logger.CreateLogger<GetParceirosQueryCommandHandler>();
            _parceirosRepository = parceirosRepository;
        }

        public async Task<GetParceirosResponse> Handle(GetParceirosQueryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetParceirosQueryCommandHandler)}");
                var response = await _parceirosRepository.GetAllAsync();
                _logger.LogInformation($"Sucesso serviço {nameof(GetParceirosQueryCommandHandler)}");

                return new GetParceirosResponse(response);
            }
            catch (Exception)
            {
                _logger.LogError($"Erro serviço {nameof(GetParceirosQueryCommandHandler)}");

                throw;
            }
        }
    }
}
