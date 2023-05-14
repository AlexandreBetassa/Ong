using MediatR;
using System.Net;

namespace Ong.Domain.Queries.Animal.GetAllAnimal
{
    public class GetAllAnimalQuery : IRequest<GetAllAnimalResponse>
    {
    }
}
