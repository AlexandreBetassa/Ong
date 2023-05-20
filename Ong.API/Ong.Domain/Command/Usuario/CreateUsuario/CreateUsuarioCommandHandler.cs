using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Interfaces.Base;
using System.Net;

namespace Ong.Domain.Command.Usuario.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(ILoggerFactory loggerFactory, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateUsuarioCommandHandler>();
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateUsuarioCommandHandler)} || Cadastro Pessoa {request.Nome}");

                var pessoa = _mapper.Map<Entities.Usuario>(request);

                await _unityOfWork.UsuarioRepository.CreateAsync(pessoa);
                await _unityOfWork.Save();

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
