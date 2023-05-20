using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Parceiros.DeleteParceiro
{
    public class DeleteParceiroCommandHandler : IRequestHandler<DeleteParceiroCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public DeleteParceiroCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteParceiroCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<Unit> Handle(DeleteParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.IdParceiro}");

                var parceiroDelete = await FindParceiroToDelete(request);

                if (parceiroDelete == null) throw new ArgumentException($"Parceiro {request.IdParceiro} não localizado");

                await _unityOfWork.ParceiroRepository.DeleteAsync(parceiroDelete);
                await _unityOfWork.Save();

                _logger.LogInformation($"Sucesso método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.IdParceiro}");

                return Unit.Value;
            }
            catch (Exception)
            {
                _logger.LogError($"Erro método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.IdParceiro}");

                throw;
            }
        }

        private async Task<ParceiroOng> FindParceiroToDelete(DeleteParceiroCommand request)
        {
            var parceiroDelete = await _unityOfWork.ParceiroRepository.GetByIdAsync(request.IdParceiro);
            return parceiroDelete is null ? throw new ArgumentException("Parceiro não localizado") : parceiroDelete;
        }
    }
}
