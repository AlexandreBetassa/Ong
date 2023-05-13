using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Command.Parceiros.DeleteParceiro
{
    public class DeleteParceiroCommandHandler : IRequestHandler<DeleteParceiroCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IParceirosRepository _parceirosRepository;
        private readonly IMapper _mapper;

        public DeleteParceiroCommandHandler(ILoggerFactory loggerFactory, IParceirosRepository parceirosRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteParceiroCommandHandler>();
            _mapper = mapper;
            _parceirosRepository = parceirosRepository;
        }

        public async Task<Unit> Handle(DeleteParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.NomeParceiro}");

                var parceiroDelete = await FindParceiroToDelete(request);
                if (parceiroDelete == null) throw new ArgumentException($"Parceiro {request.NomeParceiro} não localziado");
                await _parceirosRepository.DeleteAsync(parceiroDelete);

                _logger.LogInformation($"Sucesso método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.NomeParceiro}");

                return Unit.Value;
            }
            catch (Exception)
            {
                _logger.LogError($"Erro método {nameof(DeleteParceiroCommandHandler)} || Delete parceiro: {request.NomeParceiro}");

                throw;
            }
        }

        private async Task<ParceiroOng> FindParceiroToDelete(DeleteParceiroCommand request)
        {
            var parceiroDelete = await _parceirosRepository.GetParceiroByName(request.NomeParceiro);
            return parceiroDelete is null ? throw new ArgumentException("Parceiro não localizado") : parceiroDelete;
        }
    }
}
