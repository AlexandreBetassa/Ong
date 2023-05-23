using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ong.API.Controllers.v1.Base;
using Ong.Domain.Command.Parceiros.CreateParceiro;
using Ong.Domain.Command.Parceiros.DeleteParceiro;
using Ong.Domain.Command.Parceiros.UpdateParceiro;
using Ong.Domain.Queries.Parceiro.GetAllParceiro;

namespace Ong.API.Controllers.v1
{
    [Route("api/v1/parceiros")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ParceiroController : BaseController
    {
        private readonly IMediator _mediator;
        public ParceiroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParceiro(CreateParceiroCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetParceiro()
        {
            return await GenerateResponseCode(async () => await _mediator.Send(new GetAllParceirosQuery()));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParceiro([FromQuery] DeleteParceiroCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateParceiro([FromBody] UpdateParceiroCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }
    }
}
