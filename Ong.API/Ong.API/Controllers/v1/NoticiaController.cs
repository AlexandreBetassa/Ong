using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ong.API.Controllers.v1.Base;
using Ong.Domain.Command.Noticias.CreateNoticia;
using Ong.Domain.Command.Noticias.DeleteNoticia;
using Ong.Domain.Command.Noticias.UpdateNoticia;
using Ong.Domain.Queries.Noticia.GetAllNoticia;

namespace Ong.API.Controllers.v1
{
    [Route("api/v1/noticia")]
    [ApiController]
    [Authorize(Roles = "Admin, Usuario")]
    public class NoticiaController : BaseController
    {
        private readonly IMediator _mediator;

        public NoticiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNoticia([FromBody] CreateNoticiaCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllNoticia()
        {
            return await GenerateResponseCode(async () => await _mediator.Send(new GetAllNoticiasQuery()));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNoticia([FromQuery] DeleteNoticiaCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request, CancellationToken.None));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNoticia([FromBody] UpdateAnimalCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request, CancellationToken.None));
        }
    }
}
