using Ong.Domain.Interfaces.Base;

namespace Ong.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public char Genero { get; set; }
        public bool PossuiAnimais { get; set; }
        public Endereco Endereco { get; set; }
        public Contato Contato { get; set; }
        public Authentication authentication { get; set; }
    }
}
