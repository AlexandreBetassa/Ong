using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ong.Domain.Queries.Animal.GetAnimal
{
    public class GetAnimalQuery : IRequest<GetAnimalQueryResponse>
    {
        public int Id { get; set; }
    }
}
