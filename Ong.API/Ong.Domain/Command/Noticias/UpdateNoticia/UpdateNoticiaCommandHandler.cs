using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using System.Net;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateNoticiaCommandHandler : BaseHandler<UpdateNoticiaCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public UpdateNoticiaCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<UpdateNoticiaCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(UpdateNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateNoticiaCommandHandler)} || Update noticia: {request.Titulo}");

                var noticia = await UnityOfWork.NoticiaRepository.GetByIdAsync(request.Id);
                if (noticia == null) throw new ArgumentException("Noticia não localizada");

                noticia = Mapper.Map<Noticia>(request);

                await UnityOfWork.NoticiaRepository.UpdateAsync(noticia);
                await UnityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateNoticiaCommandHandler)} || Update noticia: {request.Titulo}");

                return Create(204, Unit.Value);
            }
            catch (Exception e)
            {
                _logger.LogError
                    ($"Erro método {nameof(UpdateAnimalCommandHandler)} || Update noticia: {request.Titulo} ||" +
                    $"Erro: {e.Message}");

                throw;
            }
        }
    }
}
