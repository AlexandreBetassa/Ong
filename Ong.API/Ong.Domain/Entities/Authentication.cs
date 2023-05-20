using Ong.Domain.Entities.Base;

namespace Ong.Domain.Entities
{
    public class Authentication : BaseEntity
    {
        public string EmailUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
