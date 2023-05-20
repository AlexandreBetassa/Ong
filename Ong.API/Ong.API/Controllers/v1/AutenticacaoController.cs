using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.Autenticacao.CreateToken;

namespace Ong.API.Controllers.v1
{
    [Route("api/v1/autenticacao")]
    [ApiController]
    [AllowAnonymous]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] CreateTokenCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
