using Microsoft.AspNetCore.Mvc;

namespace ApiLerCSVFuncionario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LerCSVFuncionarioController : ControllerBase
    {
        private readonly ILogger<LerCSVFuncionarioController> _logger;

        [HttpGet("/on")]
        public Object AplicationOn()
        {
            return Ok("Teste");
        }
    }
}
