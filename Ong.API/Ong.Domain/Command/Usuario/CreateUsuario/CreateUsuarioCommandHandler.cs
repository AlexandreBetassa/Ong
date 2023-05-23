using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Usuario.CreateUsuario
{
    public class CreateUsuarioCommandHandler : BaseHandler<CreateUsuarioCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public CreateUsuarioCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<CreateUsuarioCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Iniciado serviço {nameof(CreateUsuarioCommandHandler)} || Cadastro Pessoa {request.Nome}");

                var pessoa = Mapper.Map<Entities.Usuario>(request);

                await UnityOfWork.UsuarioRepository.CreateAsync(pessoa);
                await UnityOfWork.Save();

                _logger.LogInformation($"Sucesso serviço {nameof(CreateUsuarioCommandHandler)} || Cadastro Pessoa {request.Nome}");

                return Create(201, Unit.Value);
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
