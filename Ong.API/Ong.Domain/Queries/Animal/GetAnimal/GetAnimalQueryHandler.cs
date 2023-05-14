using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalQueryHandler : IRequestHandler<GetAnimalQuery, GetAnimalResponse>
    {
        private readonly ILogger _logger;
        private readonly IAnimalRepository _animalRepository;

        public GetAnimalQueryHandler(ILoggerFactory loggerFactory, IAnimalRepository animalRepository)
        {
            _logger = loggerFactory.CreateLogger<GetAnimalQueryHandler>();
            _animalRepository = animalRepository;
        }

        public async Task<GetAnimalResponse> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id}");

                var animal = await _animalRepository.GetByIdAsync(request.Id);

                _logger.LogInformation($"Sucesso serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id}");

                return animal == null ? throw new ArgumentException("Animal não localizado") : new GetAnimalResponse(animal);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id}");

                throw;
            }
        }
    }
}
