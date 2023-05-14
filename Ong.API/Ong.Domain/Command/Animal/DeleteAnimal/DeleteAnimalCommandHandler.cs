using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Noticias.DeleteNoticia;
using Ong.Domain.Interfaces;
using System.Net;

namespace Ong.Domain.Command.Animal.DeleteAnimal
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public DeleteAnimalCommandHandler(ILoggerFactory loggerFactory, IAnimalRepository animalRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteNoticiaCommandHandler>();
            _mapper = mapper;
            _animalRepository = animalRepository;
        }
        public async Task<HttpStatusCode> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteAnimalCommandHandler)} || Delete Animal: {request.IdAnimal}");

                var animal = await _animalRepository.GetByIdAsync(request.IdAnimal);
                if (animal == null) throw new ArgumentException("Animal não localizado");

                await _animalRepository.DeleteAsync(animal);
                _logger.LogInformation($"Sucesso método {nameof(DeleteAnimalCommandHandler)} || Delete Animal: {request.IdAnimal}");

                return HttpStatusCode.NoContent;
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro método {nameof(DeleteAnimalCommandHandler)} || Delete Animal: {request.IdAnimal}");

                throw;
            }
        }
    }
}
