using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Parceiros.UpdateParceiro
{
    public class UpdateParceiroCommandHandler : BaseHandler<UpdateParceiroCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public UpdateParceiroCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<UpdateParceiroCommandHandler>();
        }


        public override async Task<ObjectResult> Handle(UpdateParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                var parceiro = await UnityOfWork.ParceiroRepository.GetByIdAsync(request.Id);
                if (parceiro == null) throw new ArgumentException("Parceiro não localizado!!!");

                var parceiroNew = Mapper.Map<ParceiroOng>(request);

                await UnityOfWork.ParceiroRepository.UpdateAsync(parceiroNew);
                await UnityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                return Create(204, Unit.Value);
            }
            catch (Exception e)
            {
                _logger.LogError
                    ($"Erro método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome} || " +
                     $"Mensagem: {e.Message}");

                throw;
            }
        }
    }
}
