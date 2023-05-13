using Ong.Domain.Entities;

namespace Ong.Domain.Queries.GetAllNoticia
{
    public class GetAllNoticiasResponse
    {
        public GetAllNoticiasResponse(IEnumerable<Noticia> noticias)
        {
            Noticias = noticias;
        }
        public IEnumerable<Noticia> Noticias { get; set; }
    }
}