using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Queries.Noticia.GetAllNoticia
{
    public class GetAllNoticiasQueryHandler : BaseHandler<GetAllNoticiasQuery, ObjectResult>
    {
        private readonly ILogger _logger;

        public GetAllNoticiasQueryHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger)
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<GetAllNoticiasQueryHandler>();
        }

        public override async Task<ObjectResult> Handle(GetAllNoticiasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(GetAllNoticiasQueryHandler)}");

                var noticias = await UnityOfWork.NoticiaRepository.GetAllAsync();

                _logger.LogInformation($"Sucesso serviço {nameof(GetAllNoticiasQueryHandler)}");

                return Create(200, noticias);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Erro serviço {nameof(GetAllNoticiasQueryHandler)} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
