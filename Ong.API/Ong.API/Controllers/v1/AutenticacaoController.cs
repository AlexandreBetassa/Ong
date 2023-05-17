using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ong.API.Controllers.v1
{
    [Route("api/v1/autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<IActionResult> Authenticate()
        //{

        //}
    }
}
