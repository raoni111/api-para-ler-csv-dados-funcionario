using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILerCSVFuncionario.Domain.Entity
{
    public class FuncionariosEntity
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? CPF { get; set; } 
        public string? EntryDate { get; set; }
        public decimal? Salary { get; set; }
    }
}
