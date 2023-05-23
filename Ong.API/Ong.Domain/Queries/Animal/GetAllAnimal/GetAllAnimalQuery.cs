using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Queries.Animal.GetAllAnimal
{
    public class GetAllAnimalQuery : IRequest<ObjectResult>
    {
    }
}
