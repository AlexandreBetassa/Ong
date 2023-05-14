using MediatR;
using System.Net;

namespace Ong.Domain.Command.Animal.DeleteAnimal
{
    public class DeleteAnimalCommand : IRequest<HttpStatusCode>
    {
        public int IdAnimal { get; set; }
    }
}
