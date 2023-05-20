using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Noticias.DeleteNoticia
{
    public class DeleteNoticiaCommandHandler : IRequestHandler<DeleteNoticiaCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public DeleteNoticiaCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteNoticiaCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork; 
        }

        public async Task<Unit> Handle(DeleteNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Id}");

                var noticia = await _unityOfWork.NoticiaRepository.GetByIdAsync(request.Id);
                if (noticia == null) throw new ArgumentNullException($"Título {request.Id} não localizado");

                await _unityOfWork.NoticiaRepository.DeleteAsync(noticia);
                await _unityOfWork.Save();

                _logger.LogInformation($"Sucesso método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Id}");

                return Unit.Value;
            }
            catch (Exception)
            {
                _logger.LogError($"Erro método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Id}");

                throw;
            }
        }
    }
}
