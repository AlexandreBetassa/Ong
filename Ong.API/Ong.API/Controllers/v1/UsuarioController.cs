using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.Usuario.CreateUsuario;
using Ong.Domain.Command.Usuario.DeleteUsuario;
using Ong.Domain.Command.Usuario.UpdateUsuario;
using Ong.Domain.Queries.Usuario.GetAllUsuario;

namespace Ong.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoa([FromBody] CreateUsuarioCommand request)
        {
            return Ok(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            return Ok(await _mediator.Send(new GetAllUsuarioQuery(), CancellationToken.None));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario([FromQuery] DeleteUsuarioCommand request)
        {
            return Ok(await _mediator.Send(request, CancellationToken.None));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] UpdateUsuarioCommand request)
        {
            return Ok(await _mediator.Send(request, CancellationToken.None));
        }
    }
}
