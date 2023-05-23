using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Noticias.CreateNoticia
{
    public class CreateNoticiaCommandHandler : BaseHandler<CreateNoticiaCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public CreateNoticiaCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<CreateNoticiaCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(CreateNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateNoticiaCommandHandler)} || Cadastro Noticia {request.Titulo}");

                var noticia = Mapper.Map<Noticia>(request);

                var result = await UnityOfWork.NoticiaRepository.CreateAsync(noticia);
                await UnityOfWork.Save();

                _logger.LogInformation($"Sucesso serviço {nameof(CreateNoticiaCommandHandler)} || Cadastro Noticia {request.Titulo}");

                return Create(201, Unit.Value);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(CreateNoticiaCommandHandler)} || Cadastro Noticia {request.Titulo} || " +
                    $"Erro: {e.Message}");

                throw;
            }
        }
    }
}
