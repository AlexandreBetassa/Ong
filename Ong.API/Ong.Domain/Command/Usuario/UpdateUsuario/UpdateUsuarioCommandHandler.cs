using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Parceiros.UpdateParceiro;
using Ong.Domain.Interfaces.Base;
using System.Net;

namespace Ong.Domain.Command.Usuario.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public UpdateUsuarioCommandHandler
            (ILoggerFactory loggerFactory, IMapper mapper, IUnityOfWork unityOfWork)
        {
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<UpdateParceiroCommandHandler>();
            _unityOfWork = unityOfWork;
        }

        public async Task<HttpStatusCode> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                var usuario = await _unityOfWork.UsuarioRepository.GetByIdAsync(request.Id);
                if (usuario == null) throw new ArgumentException("Usuario não localizado");

                usuario = _mapper.Map<Entities.Usuario>(request);

                await _unityOfWork.UsuarioRepository.UpdateAsync(usuario);
                await _unityOfWork.Save();

                _logger.LogInformation
                    ($"Sucesso método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                return HttpStatusCode.NoContent;
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
