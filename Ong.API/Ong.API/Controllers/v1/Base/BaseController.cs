using Microsoft.AspNetCore.Mvc;

namespace Ong.API.Controllers.v1.Base
{
    public class BaseController : ControllerBase
    {
        public static async Task<ActionResult> GenerateResponseCode(Func<Task<ObjectResult>> func)
        {
            try
            {
                return await Execute(func);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task<ActionResult> Execute(Func<Task<ObjectResult>> func)
        {
            var result = await func();

            switch (result.StatusCode)
            {
                case 200:
                    return new OkObjectResult(result.Value);

                case 201:
                    return new NoContentResult();

                case 400:
                    return new BadRequestObjectResult(result.Value);

                default:
                    throw new ArgumentException("Erro Interno");
            }
        }
    }
}
