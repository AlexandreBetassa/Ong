using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Noticias.DeleteNoticia
{
    public class DeleteNoticiaCommandHandler : BaseHandler<DeleteNoticiaCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public DeleteNoticiaCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<DeleteNoticiaCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(DeleteNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Id}");

                var noticia = await UnityOfWork.NoticiaRepository.GetByIdAsync(request.Id);
                if (noticia == null) throw new ArgumentNullException($"Título {request.Id} não localizado");

                await UnityOfWork.NoticiaRepository.DeleteAsync(noticia);
                await UnityOfWork.Save();

                _logger.LogInformation($"Sucesso método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Id}");

                return Create(201, Unit.Value);
            }
            catch (Exception)
            {
                _logger.LogError($"Erro método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Id}");

                throw;
            }
        }
    }
}
