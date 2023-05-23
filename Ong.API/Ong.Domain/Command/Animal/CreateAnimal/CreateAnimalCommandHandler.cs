using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Animal.CreateAnimal
{
    public class CreateAnimalCommandHandler : BaseHandler<CreateAnimalCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public CreateAnimalCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<CreateAnimalCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateAnimalCommandHandler)} || Cadastro Animal {request.Nome}");

                var animal = Mapper.Map<Entities.Animal>(request);

                animal = await UnityOfWork.AnimalRepository.CreateAsync(animal);
                await UnityOfWork.Save();

                var response = Mapper.Map<CreateAnimalResponse>(request);
                animal = await UnityOfWork.AnimalRepository.GetByIdAsync(response.Id);

                if (animal is null) throw new ArgumentException("Erro no cadastramento do animal");

                _logger.LogInformation($"Sucesso serviço {nameof(CreateAnimalCommandHandler)} || Cadastro Animal {request.Nome}");

                return Create(201);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(CreateAnimalCommandHandler)} || Cadastro Animal {request.Nome} || Erro: {e.Message}");
                
                throw;
            }
        }
    }
}
