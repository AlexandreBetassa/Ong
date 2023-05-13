using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Entities
{
    public class Noticia : IBaseEntity
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Data { get; set; }
        public string Categoria { get; set; }
        public string Link { get; set; }
    }
}
