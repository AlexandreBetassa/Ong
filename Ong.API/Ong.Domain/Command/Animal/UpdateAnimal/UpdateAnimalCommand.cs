using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateAnimalCommand : IRequest<HttpStatusCode>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Informacoes { get; set; }
        public int Idade { get; set; }
        public string UrlImagem { get; set; }
    }
}
