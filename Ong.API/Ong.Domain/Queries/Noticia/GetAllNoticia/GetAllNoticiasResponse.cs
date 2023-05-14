namespace Ong.Domain.Queries.Noticia.GetAllNoticia
{
    public class GetAllNoticiasResponse
    {
        public GetAllNoticiasResponse(IEnumerable<Entities.Noticia> noticias)
        {
            Noticias = noticias;
        }
        public IEnumerable<Entities.Noticia> Noticias { get; set; }
    }
}