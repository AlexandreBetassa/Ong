using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Command.CreateParceiro
{
    public class CreateParceiroCommandHandler : IRequestHandler<CreateParceiroCommand, ParceirosOng>
    {
        private readonly ILogger _logger;
        private readonly IParceirosRepository _parceirosRepository;
        private readonly IMapper _mapper;

        public CreateParceiroCommandHandler(ILoggerFactory loggerFactory, IParceirosRepository parceirosRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateParceiroCommandHandler>();
            _parceirosRepository = parceirosRepository;
            _mapper = mapper;
        }

        public async Task<ParceirosOng> Handle(CreateParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateParceiro)} || Cadastro Parceiro {request.Nome}");

                var parceiroOng = _mapper.Map<ParceirosOng>(request);

                _logger.LogInformation($"Parceiro Cadastrado com sucesso {nameof(CreateParceiro)} || Cadastro Parceiro {request.Nome}");
                return await _parceirosRepository.CreateAsync(parceiroOng);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Erro cadastro parceiro {nameof(CreateParceiro)} || Cadastro Parceiro {request.Nome}");
                throw;
            }
            finally
            {
                _logger.LogInformation($"Finalizado serviço {nameof(CreateParceiro)} || Cadastro Parceiro {request.Nome}");
            }
        }
    }
}
