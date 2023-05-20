using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;

namespace Ong.Domain.Queries.Parceiro.GetAllParceiro
{
    public class GetAllParceirosQueryHandler : IRequestHandler<GetAllParceirosQuery, GetAllParceirosQueryResponse>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;

        public GetAllParceirosQueryHandler(ILoggerFactory logger, IUnityOfWork unityOfWork)
        {
            _logger = logger.CreateLogger<GetAllParceirosQueryHandler>();
            _unityOfWork = unityOfWork;
        }

        public async Task<GetAllParceirosQueryResponse> Handle(GetAllParceirosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllParceirosQueryHandler)}");
                var response = await _unityOfWork.ParceiroRepository.GetAllAsync();
                _logger.LogInformation($"Sucesso serviço {nameof(GetAllParceirosQueryHandler)}");

                return new GetAllParceirosQueryResponse(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAllParceirosQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
