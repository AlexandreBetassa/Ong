using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Animal.CreateAnimal;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Net;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public UpdateAnimalCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<UpdateAnimalCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateAnimalCommandHandler)} || Update Animal: {request.Id}");

                var animal = await _unityOfWork.AnimalRepository.GetByIdAsync(request.Id);
                if (animal == null) throw new ArgumentException("Animal não localizado");

                animal = _mapper.Map<Entities.Animal>(request);

                await _unityOfWork.AnimalRepository.UpdateAsync(animal);
                await _unityOfWork.Save();

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
