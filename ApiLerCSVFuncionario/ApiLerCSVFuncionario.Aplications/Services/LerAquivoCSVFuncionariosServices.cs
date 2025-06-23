using APILerCSVFuncionario.Domain.Interfaces.Services;
using APILerCSVFuncionario.Domain.Interfaces.Repository;
using ApiLerCSVFuncionario.Domain.Interfaces.Repository;
using APILerCSVFuncionario.Domain.Entity;
using APILerCSVFuncionario.Domain.DTOs.Response;

namespace ApiLerCSVFuncionario.Aplications.Services
{
    public class LerAquivoCSVFuncionariosServices : ILerArquivoCSVFuncionariosServices
    {
        private readonly ICSVFuncionariosReader _csvFuncionariosReader;
        private readonly IFuncionariosRepository _funcionariosRepository;

        public LerAquivoCSVFuncionariosServices(ICSVFuncionariosReader csvFuncionariosReader, IFuncionariosRepository funcionariosRepository)
        {
            _csvFuncionariosReader= csvFuncionariosReader;
            _funcionariosRepository = funcionariosRepository;
        }

        /// <summary>
        /// Método le o arquivo csv enviado pelo usuario, salva os dados no banco de dados e retorna uma lista de funcionarios
        /// </summary>
        /// <param name="fileStream">Stram convertida do arquivo csv</param>
        /// <returns>Retornas uma lista de funcionarios</returns>
        public async Task<DefaultResponse<List<FuncionariosEntity>>> LerArquivoCSV(Stream fileStream)
        {
            try
            {
                var funcionariosCSV = _csvFuncionariosReader.Reader(fileStream);

                if (funcionariosCSV.Count == 0)
                {
                    return new DefaultResponse<List<FuncionariosEntity>>
                    {
                        Success = false,
                        Message = "Nenhum funcionarios encontrado"
                    };
                }

                foreach (var funcionario in funcionariosCSV)
                {
                    var result = await _funcionariosRepository.PostFuncionarios(funcionario);

                    Console.WriteLine(result.Message);
                }

                var funcionarios = await _funcionariosRepository.GetAllFuncionarios();

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
