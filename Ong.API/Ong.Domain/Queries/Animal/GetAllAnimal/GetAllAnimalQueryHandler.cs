using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;

namespace Ong.Domain.Queries.Animal.GetAllAnimal
{
    public class GetAllAnimalQueryHandler : IRequestHandler<GetAllAnimalQuery, GetAllAnimalQueryResponse>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;

        public GetAllAnimalQueryHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork)
        {
            _logger = loggerFactory.CreateLogger<GetAllAnimalQueryHandler>();
            _unityOfWork = unityOfWork;
        }

        public async Task<GetAllAnimalQueryResponse> Handle(GetAllAnimalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllAnimalQueryHandler)}");

                var animais = await _unityOfWork.AnimalRepository.GetAllAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllAnimalQueryHandler)}");

                return new GetAllAnimalQueryResponse(animais);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAllAnimalQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
