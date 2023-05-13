using MediatR;

namespace Ong.Domain.Command.Noticias.DeleteNoticia
{
    public class DeleteNoticiaCommand : IRequest<Unit>
    {
        public string Titulo { get; set; }
    }
}
