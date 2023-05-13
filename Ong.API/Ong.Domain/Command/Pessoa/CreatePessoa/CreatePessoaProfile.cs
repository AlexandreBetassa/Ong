using AutoMapper;

namespace Ong.Domain.Command.Pessoa.CreatePessoa
{
    public class CreatePessoaProfile : Profile
    {
        public CreatePessoaProfile()
        {
            CreateMap<CreatePessoaCommand, Entities.Pessoa>();
        }
    }
}
