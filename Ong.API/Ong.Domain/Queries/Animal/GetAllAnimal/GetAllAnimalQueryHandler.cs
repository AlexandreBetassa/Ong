using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Queries.Animal.GetAllAnimal
{
    public class GetAllAnimalQueryHandler : BaseHandler<GetAllAnimalQuery, ObjectResult>
    {
        private readonly ILogger _logger;

        public GetAllAnimalQueryHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<GetAllAnimalQueryHandler>();
        }

        public override async Task<ObjectResult> Handle(GetAllAnimalQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllAnimalQueryHandler)}");

                var animais = await UnityOfWork.AnimalRepository.GetAllAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllAnimalQueryHandler)}");

                var response = new GetAllAnimalQueryResponse(animais);

                return Create(200, response);    
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAllAnimalQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
