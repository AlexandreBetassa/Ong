using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Command.Noticias.CreateNoticia;

namespace Ong.Domain.Command.Autenticacao.CreateToken
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, string>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CreateTokenCommandHandler(ILoggerFactory loggerFactory, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<CreateNoticiaCommandHandler>();
            _mapper = mapper;
        }

        public Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
