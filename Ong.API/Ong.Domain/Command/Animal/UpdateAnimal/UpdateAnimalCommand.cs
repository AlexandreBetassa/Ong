using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Noticias.UpdateNoticia
{
    public class UpdateAnimalCommand : IRequest<ObjectResult>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Informacoes { get; set; }
        public int Idade { get; set; }
        public string UrlImagem { get; set; }
    }
}
