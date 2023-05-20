using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;
using System.Net;

namespace Ong.Domain.Command.Animal.DeleteAnimal
{
    public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public DeleteAnimalCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteAnimalCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteAnimalCommandHandler)} || Delete Animal: {request.IdAnimal}");

                var animal = await _unityOfWork.AnimalRepository.GetByIdAsync(request.IdAnimal);
                if (animal == null) throw new ArgumentException("Animal não localizado");

                await _unityOfWork.AnimalRepository.DeleteAsync(animal);
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
