namespace Ong.Domain.Queries.Noticia.GetAllNoticia
{
    public class GetAllNoticiasQueryResponse
    {
        public GetAllNoticiasQueryResponse(IEnumerable<Entities.Noticia> noticias)
        {
            Noticias = noticias;
        }
        public IEnumerable<Entities.Noticia> Noticias { get; set; }
    }
}