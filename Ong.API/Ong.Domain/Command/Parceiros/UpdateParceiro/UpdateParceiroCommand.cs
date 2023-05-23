using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Parceiros.UpdateParceiro
{
    public class UpdateParceiroCommand : IRequest<ObjectResult>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
