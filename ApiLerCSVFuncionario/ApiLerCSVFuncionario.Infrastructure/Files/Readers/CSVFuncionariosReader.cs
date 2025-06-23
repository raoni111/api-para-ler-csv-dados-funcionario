using APILerCSVFuncionario.Domain.Interfaces.Repository;
using APILerCSVFuncionario.Domain.Entity;
using ApiLerCSVFuncionario.Infrastructure.Files.Maper;
using System.Globalization;
using CsvHelper;

namespace ApiLerCSVFuncionario.Infrastructure.Files.Readers
{
    public class CSVFuncionariosReader : ICSVFuncionariosReader
    {
        public List<FuncionariosEntity> Reader(Stream fileStram)
        {
            var funcionarios = new List<FuncionariosEntity>();

            try
            {
                using (var reader = new StreamReader(fileStram))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CSVFuncionariosMap>();

                    funcionarios = csv.GetRecords<FuncionariosEntity>().ToList();
                }

                return funcionarios;
            } catch(Exception ex)
            {
                throw;
            }

        }
    }
}
