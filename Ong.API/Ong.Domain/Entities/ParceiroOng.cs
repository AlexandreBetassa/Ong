using Ong.Domain.Entities.Base;

namespace Ong.Domain.Entities
{
    public class ParceiroOng : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
