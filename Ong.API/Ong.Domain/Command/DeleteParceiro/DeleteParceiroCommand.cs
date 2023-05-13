using MediatR;
using Ong.Domain.Entities;

namespace Ong.Domain.Command.DeleteParceiro
{
    public class DeleteParceiroCommand : IRequest<ParceirosOng>
    {
        public string NomeParceiro { get; set; }
    }
}
