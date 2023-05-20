using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Net;

namespace Ong.Domain.Command.Animal.CreateAnimal
{
    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public CreateAnimalCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateAnimalCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateAnimalCommandHandler)} || Cadastro Animal {request.Nome}");

                var animal = _mapper.Map<Entities.Animal>(request);

                await _unityOfWork.AnimalRepository.CreateAsync(animal);
                await _unityOfWork.Save();

                _logger.LogInformation($"Sucesso serviço {nameof(CreateAnimalCommandHandler)} || Cadastro Animal {request.Nome}");

                return HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(CreateAnimalCommandHandler)} || Cadastro Animal {request.Nome} || Erro: {e.Message}");

                throw;
            }
        }
    }
}
