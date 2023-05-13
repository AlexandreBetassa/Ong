using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.CreateParceiro;
using Ong.Domain.Command.DeleteParceiro;
using Ong.Domain.Command.UpdateParceiro;
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
        public async Task<IActionResult> GetParceiro()
        {
            try
            {
                return Ok(await _mediator.Send(new GetParceirosQueryCommand(), CancellationToken.None));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParceiro([FromQuery] DeleteParceiroCommand request)
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

        [HttpPut]
        public async Task<IActionResult> UpdateParceiro([FromBody] UpdateParceiroCommand request)
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
