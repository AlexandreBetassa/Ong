using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.API.Controllers.v1.Base;
using Ong.Domain.Command.Adocao.CreateAdocao;

namespace Ong.API.Controllers.v1
{
    [Route("api/v1/adocao")]
    [ApiController]
    public class AdocaoController : BaseController
    {
        private readonly IMediator _mediator;

        public AdocaoController(IMediator madiator)
        {
            _mediator = madiator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdocao([FromBody] CreateAdocaoCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }
    }
}
