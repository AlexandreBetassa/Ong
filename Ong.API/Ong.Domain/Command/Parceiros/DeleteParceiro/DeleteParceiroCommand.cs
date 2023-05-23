using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Entities;

namespace Ong.Domain.Command.Parceiros.DeleteParceiro
{
    public class DeleteParceiroCommand : IRequest<ObjectResult>
    {
        public int IdParceiro { get; set; }
    }
}
