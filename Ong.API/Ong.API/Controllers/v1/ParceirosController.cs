using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Queries;

namespace Ong.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParceirosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParceirosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetParceiro([FromQuery]GetParceirosQueryCommand request)
        {
            try
            {
                return Ok( await _mediator.Send(request, CancellationToken.None));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
