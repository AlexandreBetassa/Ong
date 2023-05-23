using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ong.Domain.Command.Parceiros.CreateParceiro
{
    public class CreateParceiroCommand : IRequest<ObjectResult>
    {
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
