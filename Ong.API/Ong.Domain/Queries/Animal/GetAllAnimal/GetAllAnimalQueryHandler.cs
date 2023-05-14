using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Queries.Animal.GetAllAnimal
{
    public class GetAllAnimalQueryHandler : IRequestHandler<GetAllAnimalQuery, GetAllAnimalResponse>
    {
        private readonly ILogger _logger;
        private readonly IAnimalRepository _animalRepository;

        public GetAllAnimalQueryHandler(ILoggerFactory loggerFactory, IAnimalRepository animalRepository)
        {
            _logger = loggerFactory.CreateLogger<GetAllAnimalQueryHandler>();
            _animalRepository = animalRepository;
        }

        public async Task<GetAllAnimalResponse> Handle(GetAllAnimalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllAnimalQueryHandler)}");

                var animais = await _animalRepository.GetAllAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllAnimalQueryHandler)}");

                return new GetAllAnimalResponse(animais);
            }
            catch (Exception)
            {
                _logger.LogInformation($"Erro serviço {nameof(GetAllAnimalQueryHandler)}");

                throw;
            }
        }
    }
}
