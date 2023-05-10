using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Command.CreateParceiro
{
    public class CreateParceiroCommandHandler : IRequestHandler<CreateParceiroCommand, ParceirosOng>
    {
        private readonly ILogger _logger;
        private readonly IParceirosRepository _parceirosRepository;

        public CreateParceiroCommandHandler(ILoggerFactory loggerFactory, IParceirosRepository parceirosRepository)
        {
            _logger = loggerFactory.CreateLogger<CreateParceiroCommandHandler>();
            _parceirosRepository = parceirosRepository;
        }

        public Task<ParceirosOng> Handle(CreateParceiroCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
