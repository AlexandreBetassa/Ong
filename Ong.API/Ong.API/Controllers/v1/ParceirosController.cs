using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.CreateParceiro;
using Ong.Domain.Queries;

namespace Ong.API.Controllers.v1
{
    [Route("api/parceiros")]
    [ApiController]
    public class ParceirosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParceirosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParceiro(CreateParceiroCommand request)
        {
            try
            {
                var result = await _mediator.Send(request, CancellationToken.None);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetParceiro([FromQuery] GetParceirosQueryCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request, CancellationToken.None));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
