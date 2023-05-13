using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Command.Noticias.DeleteNoticia
{
    public class DeleteNoticiaCommandHandler : IRequestHandler<DeleteNoticiaCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly INoticiasRepository _noticiasRepository;
        private readonly IMapper _mapper;

        public DeleteNoticiaCommandHandler(ILoggerFactory loggerFactory, INoticiasRepository noticiasRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteNoticiaCommandHandler>();
            _mapper = mapper;
            _noticiasRepository = noticiasRepository;
        }

        public async Task<Unit> Handle(DeleteNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Titulo}");

                var noticia = await _noticiasRepository.GetByTitulo(request.Titulo);
                if (noticia == null) throw new ArgumentNullException($"Título {request.Titulo} não localizado");

                await _noticiasRepository.DeleteAsync(noticia);
                _logger.LogInformation($"Sucesso método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Titulo}");

                return Unit.Value;
            }
            catch (Exception)
            {
                _logger.LogError($"Erro método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Titulo}");

                throw;
            }
        }
    }
}
