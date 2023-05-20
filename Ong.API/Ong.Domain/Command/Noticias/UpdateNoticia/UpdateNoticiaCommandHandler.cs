using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces.Base;
using Ong.Domain.Interfaces.Repositories;
using System.Net;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateNoticiaCommandHandler : IRequestHandler<UpdateNoticiaCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public UpdateNoticiaCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<UpdateNoticiaCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(UpdateNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateNoticiaCommandHandler)} || Update noticia: {request.Titulo}");

                var noticia = await _unityOfWork.NoticiaRepository.GetByIdAsync(request.Id);
                if (noticia == null) throw new ArgumentException("Noticia não localizada");

                noticia = _mapper.Map<Noticia>(request);

                await _unityOfWork.NoticiaRepository.UpdateAsync(noticia);
                await _unityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateNoticiaCommandHandler)} || Update noticia: {request.Titulo}");

                return HttpStatusCode.NoContent;
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
