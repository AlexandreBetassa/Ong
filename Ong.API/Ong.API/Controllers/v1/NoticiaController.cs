using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.Noticias.CreateNoticia;
using Ong.Domain.Command.Noticias.DeleteNoticia;
using Ong.Domain.Command.Noticias.UpdateNoticia;
using Ong.Domain.Queries.Noticia.GetAllNoticia;

namespace Ong.API.Controllers.v1
{
    [Route("api/v1/noticia")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NoticiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNoticia([FromBody] CreateNoticiaCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request, CancellationToken.None));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNoticia()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllNoticiasQuery(), CancellationToken.None));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNoticia([FromQuery] DeleteNoticiaCommand request)
        {
            try
            {
                return StatusCode(204, await _mediator.Send(request, CancellationToken.None));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNoticia([FromBody] UpdateAnimalCommand request)
        {
            try
            {
                return StatusCode(204, await _mediator.Send(request, CancellationToken.None));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
