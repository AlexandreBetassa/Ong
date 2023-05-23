using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Queries.Noticia.GetAllNoticia
{
    public class GetAllNoticiasQuery : IRequest<ObjectResult>
    {
    }
}
