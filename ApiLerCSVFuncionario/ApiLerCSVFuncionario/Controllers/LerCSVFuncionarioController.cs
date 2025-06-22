using Microsoft.AspNetCore.Mvc;
using APILerCSVFuncionario.Domain.Interfaces.Services;
using APILerCSVFuncionario.Domain.DTOs.Response;
using APILerCSVFuncionario.Domain.Entity;
using ApiLerCSVFuncionario.Aplications.Services;

namespace ApiLerCSVFuncionario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LerCSVFuncionarioController : ControllerBase
    {
        private readonly ILogger<LerCSVFuncionarioController> _logger;
        private readonly ILerArquivoCSVFuncionariosServices _larquivoArquivoCSVFuncionariosServuces;
        
        public LerCSVFuncionarioController(ILerArquivoCSVFuncionariosServices lerArquivoCSVFuncionariosServices)
        {
            _larquivoArquivoCSVFuncionariosServuces = lerArquivoCSVFuncionariosServices;
        }


        [HttpPost("/salvarFuncionarioCSV")]
        public IActionResult SalvarFuncionario(IFormFile fileCSV)

        {
            try
            {
                Stream fileStream = fileCSV.OpenReadStream();

                var result = _larquivoArquivoCSVFuncionariosServuces.LerArquivoCSV(fileStream);

                return Ok(result);

            } catch (Exception ex)
            {
                _logger.LogError("Erro ao ler documento csv do funcionarios Controller SalvarFuncionario", ex);
                return BadRequest(new
                {
                    Success = false,
                    Message = "Erro ao ler documento csv do funcionarios"
                });
            }
        }

        [HttpGet("/on")]
        public DefaultResponse<Object> AplicationOn()
        {
            return new DefaultResponse<Object>
            {
                   Success = true,
                   Message = "Servidor esta online",
            };
        }
    }
}
