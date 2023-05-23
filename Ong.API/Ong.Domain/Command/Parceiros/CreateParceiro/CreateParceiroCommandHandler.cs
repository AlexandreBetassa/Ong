using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Parceiros.CreateParceiro
{
    public class CreateParceiroCommandHandler : BaseHandler<CreateParceiroCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public CreateParceiroCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<CreateParceiroCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(CreateParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                var parceiroOng = Mapper.Map<ParceiroOng>(request);

                await UnityOfWork.ParceiroRepository.CreateAsync(parceiroOng);
                await UnityOfWork.Save();

                _logger.LogInformation($"Finalizado com sucesso {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                return Create(201, Unit.Value);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Erro cadastro parceiro {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                throw;
            }
        }
    }
}
