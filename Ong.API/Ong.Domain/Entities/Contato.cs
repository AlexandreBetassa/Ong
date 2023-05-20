using Ong.Domain.Entities.Base;
using Ong.Domain.Enum;

namespace Ong.Domain.Entities
{
    public class Contato : BaseEntity
    {
        public string Numero { get; set; }
        public TipoContatoEnum TipoContato { get; set; }
        public int Ramal { get; set; }
    }
}
