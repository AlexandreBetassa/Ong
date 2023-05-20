using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Net;

namespace Ong.Domain.Command.Parceiros.CreateParceiro
{
    public class CreateParceiroCommandHandler : IRequestHandler<CreateParceiroCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public CreateParceiroCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateParceiroCommandHandler>();
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<HttpStatusCode> Handle(CreateParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                var parceiroOng = _mapper.Map<ParceiroOng>(request);

                await _unityOfWork.ParceiroRepository.CreateAsync(parceiroOng);
                await _unityOfWork.Save();

                _logger.LogInformation($"Finalizado com sucesso {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                return HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Erro cadastro parceiro {nameof(CreateParceiroCommandHandler)} || Cadastro Parceiro {request.Nome}");

                throw;
            }
        }
    }
}
