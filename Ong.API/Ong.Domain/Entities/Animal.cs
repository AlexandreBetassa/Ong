using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Entities
{
    public class Animal : BaseEntity
    {
        public string Nome { get; set; }
        public string Informacoes { get; set; }
        public int Idade { get; set; }
        public string UrlImagem { get; set; }
    }
}
