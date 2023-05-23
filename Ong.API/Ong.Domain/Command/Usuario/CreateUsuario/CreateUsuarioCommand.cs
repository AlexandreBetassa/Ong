using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Entities;
using Ong.Domain.Enum;

namespace Ong.Domain.Command.Usuario.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<ObjectResult>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Genero { get; set; }
        public bool PossuiAnimais { get; set; }
        public PerfilUsuarioEnum Perfil { get; set; }
        public Endereco Endereco { get; set; }
        public Contato Contato { get; set; }
        public Authentication Authentication { get; set; }
    }
}
