using System.ComponentModel;

namespace Ong.Domain.Enum
{
    public enum StatusEnum
    {
        [Description("pendente")]
        Pendente,

        [Description("aprovado")]
        Aprovado,

        [Description("recusado")]
        Recusado
    }
}
