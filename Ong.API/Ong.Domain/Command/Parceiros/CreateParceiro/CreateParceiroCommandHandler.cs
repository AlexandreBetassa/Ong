using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Infra.Data.Repositories;
using System.Net;

namespace Ong.Domain.Command.Parceiros.CreateParceiro
{
    public class CreateParceiroCommandHandler : IRequestHandler<CreateParceiroCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IParceiroRepository _parceirosRepository;
        private readonly IMapper _mapper;

        public CreateParceiroCommandHandler(ILoggerFactory loggerFactory, IParceiroRepository parceirosRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateParceiroCommandHandler>();
            _parceirosRepository = parceirosRepository;
            _mapper = mapper;
        }

        public async Task<HttpStatusCode> Handle(CreateParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                var parceiroOng = _mapper.Map<ParceiroOng>(request);
                await _parceirosRepository.CreateAsync(parceiroOng);

                _logger.LogInformation($"Finalizado com sucesso {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                return HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Erro cadastro parceiro {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                _logger.LogInformation($"Finalizado serviço {nameof(CreateParceiro)} || Cadastro Parceiro {request.Nome}");
            }
        }
    }
}
