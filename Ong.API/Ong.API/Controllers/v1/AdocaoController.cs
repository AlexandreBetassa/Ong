using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.Adocao.CreateAdocao;

namespace Ong.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdocaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdocaoController(IMediator madiator)
        {
            _mediator = madiator;   
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdocao([FromBody] CreateAdocaoCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}
