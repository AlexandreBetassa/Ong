using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Parceiros.UpdateParceiro;
using Ong.Domain.Interfaces;
using System.Net;

namespace Ong.Domain.Command.Usuario.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, HttpStatusCode>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUsuarioReppository _usuarioRepository;

        public UpdateUsuarioCommandHandler
            (ILoggerFactory loggerFactory, IMapper mapper, IUsuarioReppository usuarioRepository)
        {
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<UpdateParceiroCommandHandler>();
            _usuarioRepository = usuarioRepository;
        }

        public async Task<HttpStatusCode> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation
                    ($"Iniciado método {nameof(UpdateParceiroCommandHandler)} para atualização do parceiro {request.Nome}");

                var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
                if (usuario == null) throw new ArgumentException("Usuario não localizado");

                usuario = _mapper.Map<Entities.Usuario>(request);

            }
            catch (Exception e)
            {

            }
            throw new NotImplementedException();
        }
    }
}
