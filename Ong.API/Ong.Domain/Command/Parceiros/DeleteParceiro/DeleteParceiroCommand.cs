using MediatR;
using Ong.Domain.Entities;

namespace Ong.Domain.Command.Parceiros.DeleteParceiro
{
    public class DeleteParceiroCommand : IRequest<Unit>
    {
        public int IdParceiro { get; set; }
    }
}
