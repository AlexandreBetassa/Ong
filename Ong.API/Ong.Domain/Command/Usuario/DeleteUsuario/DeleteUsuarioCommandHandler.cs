using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;
using System.Net;

namespace Ong.Domain.Command.Usuario.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUsuarioReppository _usuarioReppository;
        private readonly IMapper _mapper;

        public DeleteUsuarioCommandHandler(IUsuarioReppository usuarioReppository, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DeleteUsuarioCommandHandler>();
            _mapper = mapper;
            _usuarioReppository = usuarioReppository;
        }

        async Task<HttpStatusCode> IRequestHandler<DeleteUsuarioCommand, HttpStatusCode>.Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(DeleteUsuarioCommandHandler)} || Delete Usuario: {request.IdPessoa}");

                var pessoa = await _usuarioReppository.GetByIdAsync(request.IdPessoa);
                if (pessoa == null) throw new ArgumentException("Usuario não localizado");

                await _usuarioReppository.DeleteAsync(pessoa);

                _logger.LogInformation
                        ($"Sucesso método {nameof(DeleteUsuarioCommandHandler)} || Delete Usuario: {request.IdPessoa}");

                return HttpStatusCode.NoContent;
            }
            catch (Exception)
            {
                _logger.LogError
                        ($"Sucesso método {nameof(DeleteUsuarioCommandHandler)} || Delete Usuario: {request.IdPessoa}");

                throw;

            }
        }
    }
}
