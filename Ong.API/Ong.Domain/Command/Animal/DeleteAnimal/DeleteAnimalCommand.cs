using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Animal.DeleteAnimal
{
    public class DeleteAnimalCommand : IRequest<ObjectResult>
    {
        public int IdAnimal { get; set; }
    }
}
