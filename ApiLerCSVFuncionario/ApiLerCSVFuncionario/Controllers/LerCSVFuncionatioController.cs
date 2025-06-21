using Microsoft.AspNetCore.Mvc;

namespace ApiLerCSVFuncionario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LerCSVFuncionatioController : ControllerBase
    {
        private readonly ILogger<LerCSVFuncionatioController> _logger;

        [HttpGet("/on")]
        public Object AplicationOn()
        {
            return Ok("Teste");
        }
    }
}
