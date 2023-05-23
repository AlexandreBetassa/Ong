using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Animal.DeleteAnimal
{
    public class DeleteAnimalCommandHandler : BaseHandler<DeleteAnimalCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public DeleteAnimalCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger)
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<DeleteAnimalCommandHandler>();    
        }

        public override async Task<ObjectResult> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteAnimalCommandHandler)} || Delete Animal: {request.IdAnimal}");

                var animal = await UnityOfWork.AnimalRepository.GetByIdAsync(request.IdAnimal);
                if (animal == null) throw new ArgumentException("Animal não localizado");

                await UnityOfWork.AnimalRepository.DeleteAsync(animal);
                _logger.LogInformation($"Sucesso método {nameof(DeleteAnimalCommandHandler)} || Delete Animal: {request.IdAnimal}");

                return Create(201);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro método {nameof(DeleteAnimalCommandHandler)} || Delete Animal: {request.IdAnimal}");

                throw;
            }
        }

    }
}
