using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Base;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Command.Usuario.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : BaseHandler<DeleteUsuarioCommand, ObjectResult>
    {
        private readonly ILogger _logger;

        public DeleteUsuarioCommandHandler
            (IMediator mediator, IMapper mapper, IUnityOfWork unityOfWork, ILoggerFactory logger) 
            : base(mediator, mapper, unityOfWork, logger)
        {
            _logger = logger.CreateLogger<DeleteUsuarioCommandHandler>();
        }

        public override async Task<ObjectResult> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(DeleteUsuarioCommandHandler)} || Delete Usuario: {request.IdPessoa}");

                var pessoa = await UnityOfWork.UsuarioRepository.GetByIdAsync(request.IdPessoa);
                if (pessoa == null) throw new ArgumentException("Usuario não localizado");

                await UnityOfWork.UsuarioRepository.DeleteAsync(pessoa);
                await UnityOfWork.Save();

                _logger.LogInformation
                        ($"Sucesso método {nameof(DeleteUsuarioCommandHandler)} || Delete Usuario: {request.IdPessoa}");

                return Create(204, Unit.Value);
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
