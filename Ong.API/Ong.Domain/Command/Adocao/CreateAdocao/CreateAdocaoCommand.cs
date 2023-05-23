using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.Domain.Command.Adocao.CreateAdocao
{
    public class CreateAdocaoCommand : IRequest<ObjectResult>
    {
        public string CpfCandidato { get; set; }
        public int IdAnimal { get; set; }
    }
}
