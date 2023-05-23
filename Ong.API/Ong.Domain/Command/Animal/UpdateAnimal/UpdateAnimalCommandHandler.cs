using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateAnimalCommandHandler : BaseHandler<UpdateAnimalCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public UpdateAnimalCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger)
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<UpdateAnimalCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateAnimalCommandHandler)} || Update Animal: {request.Id}");

                var animal = await UnityOfWork.AnimalRepository.GetByIdAsync(request.Id);
                if (animal == null) throw new ArgumentException("Animal não localizado");

                animal = Mapper.Map<Entities.Animal>(request);

                await UnityOfWork.AnimalRepository.UpdateAsync(animal);
                await UnityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateAnimalCommandHandler)} || Update Animal: {request.Id}");

                return Create(204, Unit.Value);
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
