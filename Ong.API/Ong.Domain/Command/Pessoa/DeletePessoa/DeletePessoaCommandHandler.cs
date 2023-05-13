using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Parceiros.DeleteParceiro;
using Ong.Domain.Interfaces;
using Ong.Infra.Data.Repositories;
using System.Net;

namespace Ong.Domain.Command.Pessoa.DeletePessoa
{
    public class DeletePessoaCommandHandler : IRequestHandler<DeletePessoaCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUsuarioReppository _pessoaReppository;
        private readonly IMapper _mapper;

        public DeletePessoaCommandHandler(IUsuarioReppository pessoaReppository, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DeletePessoaCommandHandler>();
            _mapper = mapper;
            _pessoaReppository = pessoaReppository;
        }

        async Task<HttpStatusCode> IRequestHandler<DeletePessoaCommand, HttpStatusCode>.Handle(DeletePessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(DeletePessoaCommandHandler)} || Delete parceiro: {request.IdPessoa}");

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
