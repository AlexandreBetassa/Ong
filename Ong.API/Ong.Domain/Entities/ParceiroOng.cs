using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Entities
{
    public class ParceiroOng : IBaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
