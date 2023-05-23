using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Noticias.DeleteNoticia
{
    public class DeleteNoticiaCommand : IRequest<ObjectResult>
    {
        public int Id { get; set; }
    }
}
