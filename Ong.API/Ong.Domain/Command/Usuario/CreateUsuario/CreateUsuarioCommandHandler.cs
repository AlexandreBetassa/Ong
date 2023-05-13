using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces;
using System.Net;

namespace Ong.Domain.Command.Usuario.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUsuarioReppository _pessoaRepository;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(ILoggerFactory loggerFactory, IUsuarioReppository pessoaReppository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateUsuarioCommandHandler>();
            _mapper = mapper;
            _pessoaRepository = pessoaReppository;
        }

        public async Task<HttpStatusCode> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateUsuarioCommandHandler)} || Cadastro Pessoa {request.Nome}");

                var pessoa = _mapper.Map<Entities.Usuario>(request);
                await _pessoaRepository.CreateAsync(pessoa);

                _logger.LogInformation($"Sucesso serviço {nameof(CreateUsuarioCommandHandler)} || Cadastro Pessoa {request.Nome}");

                return HttpStatusCode.Created;
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro serviço {nameof(CreateUsuarioCommandHandler)} || Cadastro Pessoa {request.Nome} || " +
                    $"Erro: {e.Message}");

                throw;
            }
        }
    }
}
