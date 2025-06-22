using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APILerCSVFuncionario.Domain.Entity;

namespace ApiLerCSVFuncionario.Infrastructure.Files.Maper
{
    internal class CSVFuncionariosMap : CsvHelper.Configuration.ClassMap<FuncionariosEntity>
    {
        public CSVFuncionariosMap()
        {
            Map(m => m.Name).Name("Name");
            Map(m => m.Age).Name("Age");
            Map(m => m.CPF).Name("CPF");
            Map(m => m.EntryDate).Name("EntryDate");
            Map(m => m.Salary).Name("Salary");
        }
    }
}
