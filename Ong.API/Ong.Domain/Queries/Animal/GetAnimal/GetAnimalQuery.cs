using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalQuery : IRequest<ObjectResult>
    {
        public int Id { get; set; }
    }
}
