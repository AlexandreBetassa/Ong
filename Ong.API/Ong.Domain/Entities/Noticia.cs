using Ong.Domain.Entities.Base;

namespace Ong.Domain.Entities
{
    public class Noticia : BaseEntity
    {
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Data { get; set; }
        public string Categoria { get; set; }
        public string Link { get; set; }
    }
}
