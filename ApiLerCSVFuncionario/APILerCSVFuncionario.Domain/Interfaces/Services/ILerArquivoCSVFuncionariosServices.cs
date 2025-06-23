using APILerCSVFuncionario.Domain.DTOs.Response;
using APILerCSVFuncionario.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILerCSVFuncionario.Domain.Interfaces.Services
{
    public interface ILerArquivoCSVFuncionariosServices
    {
        public Task<DefaultResponse<List<FuncionariosEntity>>> LerArquivoCSV(Stream fileStream);
    }
}
