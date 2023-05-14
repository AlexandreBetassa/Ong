using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalQuery : IRequest<GetAnimalResponse>
    {
        public int Id { get; set; }
    }
}
