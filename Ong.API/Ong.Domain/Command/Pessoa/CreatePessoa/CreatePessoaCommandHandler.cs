using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;
using System.Net;

namespace Ong.Domain.Command.Pessoa.CreatePessoa
{
    public class CreatePessoaCommandHandler : IRequestHandler<CreatePessoaCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUsuarioReppository _pessoaRepository;
        private readonly IMapper _mapper;

        public CreatePessoaCommandHandler(ILoggerFactory loggerFactory, IUsuarioReppository pessoaReppository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreatePessoaCommandHandler>();
            _mapper = mapper;
            _pessoaRepository = pessoaReppository;
        }

        public async Task<HttpStatusCode> Handle(CreatePessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreatePessoaCommandHandler)} || Cadastro Pessoa {request.Nome}");

                var pessoa = _mapper.Map<Entities.Usuario>(request);
                await _pessoaRepository.CreateAsync(pessoa);

                _logger.LogInformation($"Sucesso serviço {nameof(CreatePessoaCommandHandler)} || Cadastro Pessoa {request.Nome}");

                return HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(CreatePessoaCommandHandler)} || Cadastro Pessoa {request.Nome} || " +
                    $"Erro: {e.Message}");

                throw;
            }
        }
    }
}
