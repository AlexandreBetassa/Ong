using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateNoticiaCommand : IRequest<ObjectResult>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Data { get; set; }
        public string Categoria { get; set; }
        public string Link { get; set; }
    }
}
