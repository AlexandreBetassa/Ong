using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ong.API.Controllers.v1.Base;
using Ong.Domain.Command.Animal.CreateAnimal;
using Ong.Domain.Command.Animal.DeleteAnimal;
using Ong.Domain.Command.Noticias.UpdateNoticia;
using Ong.Domain.Queries.Animal.GetAllAnimal;
using Ong.Domain.Queries.Animal.GetAnimal;

namespace Ong.API.Controllers.v1
{
    [Route("api/v1/animal")]
    [ApiController]
    public class AnimalController : BaseController
    {
        private readonly IMediator _mediator;

        public AnimalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAnimal([FromQuery] DeleteAnimalCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAnimal([FromRoute] int id, [FromBody] UpdateAnimalCommand request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }

        [HttpGet("{Id}", Name = "GetById")]
        public async Task<IActionResult> GetAnimal([FromRoute] GetAnimalQuery request)
        {
            return await GenerateResponseCode(async () => await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimal()
        {
            return await GenerateResponseCode(async () => await _mediator.Send(new GetAllAnimalQuery()));
        }
    }
}
