using Ong.Domain.Entities.Base;

namespace Ong.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

    }
}
