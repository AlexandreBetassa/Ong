using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        //[HttpPost]
        //public async Task<IActionResult> CreateAdocao([FromBody] Cre)
        //{

        //}

    }
}
