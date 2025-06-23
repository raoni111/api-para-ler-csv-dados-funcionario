using APILerCSVFuncionario.Domain.Entity;

namespace APILerCSVFuncionario.Domain.Interfaces.Repository
{
    public interface ICSVFuncionariosReader
    {
        public List<FuncionariosEntity> Reader(Stream fileStram);
    }
}
