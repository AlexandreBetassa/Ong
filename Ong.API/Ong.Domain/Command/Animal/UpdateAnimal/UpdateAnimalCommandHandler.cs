using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;
using System.Net;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public UpdateAnimalCommandHandler(ILoggerFactory loggerFactory, IAnimalRepository animalRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<UpdateAnimalCommandHandler>();
            _mapper = mapper;
            _animalRepository = animalRepository;
        }
        public async Task<HttpStatusCode> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateAnimalCommandHandler)} || Update Animal: {request.Id}");

                var animal = await _animalRepository.GetByIdAsync(request.Id);
                if (animal == null) throw new ArgumentException("Animal não localizado");

                animal = _mapper.Map<Entities.Animal>(request);
                await _animalRepository.UpdateAsync(animal);
                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateAnimalCommandHandler)} || Update Animal: {request.Id}");

                return HttpStatusCode.NoContent;
            }
            catch (Exception e)
            {
                _logger.LogError
                    ($"Erro método {nameof(UpdateAnimalCommandHandler)} || Update Animal: {request.Id} ||" +
                    $"Erro: {e.Message}");

                throw;
            }
        }
    }
}
