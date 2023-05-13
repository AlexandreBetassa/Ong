using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Infra.Data.Repositories;

namespace Ong.Domain.Command.Noticias.DeleteNoticia
{
    public class DeleteNoticiaCommandHandler : IRequestHandler<DeleteNoticiaCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly INoticiaRepository _noticiasRepository;
        private readonly IMapper _mapper;

        public DeleteNoticiaCommandHandler(ILoggerFactory loggerFactory, INoticiaRepository noticiasRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteNoticiaCommandHandler>();
            _mapper = mapper;
            _noticiasRepository = noticiasRepository;
        }

        public async Task<Unit> Handle(DeleteNoticiaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado método {nameof(DeleteNoticiaCommandHandler)} || Delete noticia: {request.Id}");

                var noticia = await _noticiasRepository.GetByIdAsync(request.Id);
                if (noticia == null) throw new ArgumentNullException($"Título {request.Id} não localizado");

                await _noticiasRepository.DeleteAsync((Noticia)noticia);
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
