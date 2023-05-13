using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateNoticiaCommand : IRequest<HttpStatusCode>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Data { get; set; }
        public string Categoria { get; set; }
        public string Link { get; set; }
    }
}
