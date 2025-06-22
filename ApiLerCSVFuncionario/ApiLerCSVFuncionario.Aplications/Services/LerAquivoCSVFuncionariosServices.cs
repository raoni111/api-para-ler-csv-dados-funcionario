using APILerCSVFuncionario.Domain.Interfaces.Services;
using APILerCSVFuncionario.Domain.Interfaces.Repository;
using APILerCSVFuncionario.Domain.Entity;
using APILerCSVFuncionario.Domain.DTOs.Response;

namespace ApiLerCSVFuncionario.Aplications.Services
{
    public class LerAquivoCSVFuncionariosServices : ILerArquivoCSVFuncionariosServices
    {
        private readonly ICSVFuncionariosReader _csvFuncionariosReader;

        public LerAquivoCSVFuncionariosServices(ICSVFuncionariosReader csvFuncionariosReader)
        {
            _csvFuncionariosReader= csvFuncionariosReader;
        }

        public DefaultResponse<List<FuncionariosEntity>> LerArquivoCSV(Stream fileStream)
        {
            try
            {
                var funcionarios = _csvFuncionariosReader.Reader(fileStream);

                if (funcionarios.Count == 0)
                {
                    return new DefaultResponse<List<FuncionariosEntity>>
                    {
                        Success = false,
                        Message = "Nenhum funcionarios encontrado"
                    };
                }

                return new DefaultResponse<List<FuncionariosEntity>> {
                    Success = true,
                    Message = $"Funcionarios encontrados: {funcionarios.Count}",
                    Data = funcionarios
                };

            } catch(Exception ex)
            {
                throw;
            }
        }
    }
}
