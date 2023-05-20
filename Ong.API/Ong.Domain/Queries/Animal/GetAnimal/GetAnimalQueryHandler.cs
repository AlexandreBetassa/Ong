using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;

namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalQueryHandler : IRequestHandler<GetAnimalQuery, GetAnimalResponse>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;

        public GetAnimalQueryHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork)
        {
            _logger = loggerFactory.CreateLogger<GetAnimalQueryHandler>();
            _unityOfWork = unityOfWork;
        }

        public async Task<GetAnimalResponse> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id}");

                var animal = await _unityOfWork.AnimalRepository.GetByIdAsync(request.Id);

                _logger.LogInformation($"Sucesso serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id}");

                return animal == null ? throw new ArgumentException("Animal não localizado") : new GetAnimalResponse(animal);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
