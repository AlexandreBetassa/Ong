using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ong.Domain.Command.Animal.CreateAnimal;
using Ong.Domain.Command.Animal.DeleteAnimal;
using Ong.Domain.Command.Noticias.UpdateNoticia;
using Ong.Domain.Queries.Animal.GetAllAnimal;
using Ong.Domain.Queries.Animal.GetAnimal;

namespace Ong.API.Controllers.v1
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnimalController(IMediator mediator)
        {
            _mediator = mediator;
        }
        int i = 1;
        string x = int.ToString();
        [HttpPost]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimalCommand request)
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

        [HttpDelete]
        public async Task<IActionResult> DeleteAnimal([FromQuery] DeleteAnimalCommand request)
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

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalCommand request)
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAnimal([FromRoute] GetAnimalQuery request)
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
        public async Task<IActionResult> GetAllAnimal()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllAnimalQuery(), CancellationToken.None));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}