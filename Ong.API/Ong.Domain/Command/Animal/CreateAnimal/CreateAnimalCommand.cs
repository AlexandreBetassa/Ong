using MediatR;
using System.Net;

namespace Ong.Domain.Command.Animal.CreateAnimal
{
    public class CreateAnimalCommand : IRequest<HttpStatusCode>
    {
        public string Nome { get; set; }
        public string Informacoes { get; set; }
        public int Idade { get; set; }
        public string UrlImagem { get; set; }
    }
}
