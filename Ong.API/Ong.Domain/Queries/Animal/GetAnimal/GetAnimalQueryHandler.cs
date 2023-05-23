using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalQueryHandler : BaseHandler<GetAnimalQuery, ObjectResult>
    {
        private readonly ILogger _logger;

        public GetAnimalQueryHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<GetAnimalQueryHandler>();

        }

        public override async Task<ObjectResult> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id}");

                var animal = await UnityOfWork.AnimalRepository.GetByIdAsync(request.Id);

                _logger.LogInformation($"Sucesso serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id}");

                return Create(200, new GetAnimalQueryResponse(animal));
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAnimalQueryHandler)} || ID Animal {request.Id} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
