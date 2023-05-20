using System.ComponentModel;

namespace Ong.Domain.Enum
{
    public enum StatusAdocaoEnum
    {
        [Description("pendente")]
        Pendente,

        [Description("aprovado")]
        Aprovado,

        [Description("recusado")]
        Recusado
    }
}
