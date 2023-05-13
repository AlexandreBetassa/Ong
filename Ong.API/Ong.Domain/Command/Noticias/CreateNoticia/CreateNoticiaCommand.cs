using MediatR;
using System.Net;

namespace Ong.Domain.Command.Noticias.CreateNoticia
{
    public class CreateNoticiaCommand : IRequest<HttpStatusCode>
    {
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Data { get; set; }
        public string Categoria { get; set; }
        public string Link { get; set; }
    }
}
