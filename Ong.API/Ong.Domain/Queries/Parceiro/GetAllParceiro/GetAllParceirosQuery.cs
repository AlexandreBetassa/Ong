using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Queries.Parceiro.GetAllParceiro
{
    public class GetAllParceirosQuery : IRequest<ObjectResult>
    {
    }
}
