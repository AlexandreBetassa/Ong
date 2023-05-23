using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Queries.Parceiro.GetAllParceiro
{
    public class GetAllParceirosQueryHandler : BaseHandler<GetAllParceirosQuery, ObjectResult>
    {
        private readonly ILogger _logger;

        public GetAllParceirosQueryHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger)
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<GetAllParceirosQueryHandler>();
        }

        public override async Task<ObjectResult> Handle(GetAllParceirosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllParceirosQueryHandler)}");
                var response = await UnityOfWork.ParceiroRepository.GetAllAsync();
                _logger.LogInformation($"Sucesso serviço {nameof(GetAllParceirosQueryHandler)}");

                return Create(200, new GetAllParceirosQueryResponse(response));
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(GetAllParceirosQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
