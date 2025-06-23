using APILerCSVFuncionario.Domain.DTOs.Response;
using APILerCSVFuncionario.Domain.Entity;

namespace ApiLerCSVFuncionario.Domain.Interfaces.Repository
{
    public interface IFuncionariosRepository
    {
        public Task<DefaultResponse<Object>> PostFuncionarios(FuncionariosEntity funcionario);
        public Task<List<FuncionariosEntity>> GetAllFuncionarios();
    }
}
