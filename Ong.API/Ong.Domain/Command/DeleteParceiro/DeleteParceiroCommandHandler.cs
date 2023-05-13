using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ong.Domain.Entities;
using Ong.Domain.Interfaces;

namespace Ong.Domain.Command.DeleteParceiro
{
    public class DeleteParceiroCommandHandler : IRequestHandler<DeleteParceiroCommand, ParceirosOng>
    {
        private readonly ILogger _logger;
        private readonly IParceirosRepository _parceirosRepository;
        private readonly IMapper _mapper;

        public DeleteParceiroCommandHandler(ILoggerFactory loggerFactory, IParceirosRepository parceirosRepository, IMapper mapper)
        {
            _logger = loggerFactory.CreateLogger<DeleteParceiroCommandHandler>();
            _mapper = mapper;
            _parceirosRepository = parceirosRepository;
        }

        public async Task<ParceirosOng> Handle(DeleteParceiroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var parceiroDelete = await FindParceiroToDelete(request);
                var result = await _parceirosRepository.DeleteAsync(parceiroDelete);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
        }

        private async Task<ParceirosOng> FindParceiroToDelete(DeleteParceiroCommand request)
        {
            var parceiroDelete = await _parceirosRepository.GetParceiroByName(request.NomeParceiro);
            return parceiroDelete is null ? throw new ArgumentException("Parceiro não localizado") : parceiroDelete;
        }
    }
}
