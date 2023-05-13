using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.Pessoa.CreatePessoa;

namespace Ong.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoa([FromBody] CreatePessoaCommand request)
        {
            return Ok(await _mediator.Send(request, CancellationToken.None));
        }
    }
}
