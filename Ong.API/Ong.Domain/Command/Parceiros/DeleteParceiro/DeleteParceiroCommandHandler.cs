using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Infra.Data.Repositories;

namespace Ong.Domain.Command.Parceiros.DeleteParceiro
{
    public class DeleteParceiroCommandHandler : IRequestHandler<DeleteParceiroCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IParceiroRepository _parceirosRepository;
        private readonly IMapper _mapper;

        public DeleteParceiroCommandHandler(ILoggerFactory loggerFactory, IParceiroRepository parceirosRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteParceiroCommandHandler>();
            _mapper = mapper;
            _parceirosRepository = parceirosRepository;
        }

        public async Task<Unit> Handle(DeleteParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.IdParceiro}");

                var parceiroDelete = await FindParceiroToDelete(request);
                if (parceiroDelete == null) throw new ArgumentException($"Parceiro {request.IdParceiro} não localziado");
                await _parceirosRepository.DeleteAsync(parceiroDelete);

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
            var parceiroDelete = await _parceirosRepository.GetByIdAsync(request.IdParceiro);
            return parceiroDelete is null ? throw new ArgumentException("Parceiro não localizado") : parceiroDelete;
        }
    }
}
