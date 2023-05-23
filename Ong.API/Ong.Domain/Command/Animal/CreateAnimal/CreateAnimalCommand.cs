using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Animal.CreateAnimal
{
    public class CreateAnimalCommand : IRequest<ObjectResult>
    {
        public string Nome { get; set; }
        public string Informacoes { get; set; }
        public int Idade { get; set; }
        public string UrlImagem { get; set; }
    }
}
