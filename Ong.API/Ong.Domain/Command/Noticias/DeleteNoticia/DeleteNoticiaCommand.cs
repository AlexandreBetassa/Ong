using MediatR;

namespace Ong.Domain.Command.Noticias.DeleteNoticia
{
    public class DeleteNoticiaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
