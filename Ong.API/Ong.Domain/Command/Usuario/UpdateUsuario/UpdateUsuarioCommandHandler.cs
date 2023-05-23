using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Command.Parceiros.UpdateParceiro;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Usuario.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : BaseHandler<UpdateUsuarioCommand, ObjectResult>
    {
        private readonly ILogger _logger;
        public UpdateUsuarioCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<UpdateParceiroCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                var usuario = await UnityOfWork.UsuarioRepository.GetByIdAsync(request.Id);
                if (usuario == null) throw new ArgumentException("Usuario não localizado");

                usuario = Mapper.Map<Entities.Usuario>(request);

                await UnityOfWork.UsuarioRepository.UpdateAsync(usuario);
                await UnityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                return Create(204, Unit.Value);
            }
            catch (Exception e)
            {

                _logger.LogError
                    ($"Erro método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome} || ERRO: {e.Message}");

                throw;
            }
        }
    }
}
