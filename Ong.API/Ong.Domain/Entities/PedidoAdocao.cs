using Ong.Domain.Enum;
using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Entities
{
    public class PedidoAdocao : BaseEntity
    {
        public Usuario Usuario { get; set; }
        public Animal Animal { get; set; }
        public StatusEnum Status { get; set; }
        public string Obervacao { get; set; }
        public string Justificativa { get; set; }
        public DateTime DataAdocao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
