using Ong.Domain.Interfaces;

namespace Ong.Domain.Entities
{
    public class ParceirosOng : IBaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UrlLogotipo { get; set; }
    }
}
