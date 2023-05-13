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
        private readonly IUsuarioReppository _pessoaReppository;
        private readonly IMapper _mapper;

        public DeleteUsuarioCommandHandler(IUsuarioReppository pessoaReppository, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DeleteUsuarioCommandHandler>();
            _mapper = mapper;
            _pessoaReppository = pessoaReppository;
        }

        async Task<HttpStatusCode> IRequestHandler<DeleteUsuarioCommand, HttpStatusCode>.Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(DeleteUsuarioCommandHandler)} || Delete parceiro: {request.IdPessoa}");

                var pessoa = await _pessoaReppository.GetByIdAsync(request.IdPessoa);
                if (pessoa == null) throw new ArgumentException("Usuario não localizado");

                return HttpStatusCode.NoContent;
            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
