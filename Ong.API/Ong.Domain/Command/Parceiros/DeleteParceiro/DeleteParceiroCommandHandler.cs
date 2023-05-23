using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Parceiros.DeleteParceiro
{
    public class DeleteParceiroCommandHandler : BaseHandler<DeleteParceiroCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public DeleteParceiroCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<DeleteParceiroCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(DeleteParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.IdParceiro}");

                var parceiroDelete = await FindParceiroToDelete(request);

                if (parceiroDelete == null) throw new ArgumentException($"Parceiro {request.IdParceiro} não localizado");

                await UnityOfWork.ParceiroRepository.DeleteAsync(parceiroDelete);
                await UnityOfWork.Save();

                _logger.LogInformation($"Sucesso método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.IdParceiro}");

                return Create(201,Unit.Value);
            }
            catch (Exception)
            {
                _logger.LogError($"Erro método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.IdParceiro}");

                throw;
            }
        }

        private async Task<ParceiroOng> FindParceiroToDelete(DeleteParceiroCommand request)
        {
            var parceiroDelete = await UnityOfWork.ParceiroRepository.GetByIdAsync(request.IdParceiro);
            return parceiroDelete is null ? throw new ArgumentException("Parceiro não localizado") : parceiroDelete;
        }
    }
}
