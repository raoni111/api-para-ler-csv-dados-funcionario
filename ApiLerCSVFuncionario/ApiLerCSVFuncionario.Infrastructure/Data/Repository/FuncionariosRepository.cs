using ApiLerCSVFuncionario.Domain.Interfaces.Repository;
using APILerCSVFuncionario.Domain.Entity;
using APILerCSVFuncionario.Domain.DTOs.Response;
using MySqlConnector;


namespace ApiLerCSVFuncionario.Infrastructure.Data.Repository
{
    public class FuncionariosRepository : IFuncionariosRepository

    {
        private readonly string _connectionString; 

        public FuncionariosRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DefaultResponse<Object>> PostFuncionarios(FuncionariosEntity funcionario)
        {

            try
            {
                using (var con = new MySqlConnection(_connectionString))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;

                        cmd.CommandText = @$"INSERT INTO funcionarios (name, age, CPF, entryDate, salary) 
                                                VALUES (@Name, @Age, @CPF, STR_TO_DATE(@Date, '%Y-%m-%d'), @Salary);";

                        cmd.Parameters.AddWithValue("@Name", funcionario.Name);
                        cmd.Parameters.AddWithValue("@Age", funcionario.Age);
                        cmd.Parameters.AddWithValue("@CPF", funcionario.CPF);
                        cmd.Parameters.AddWithValue("@Date", funcionario.EntryDate);
                        cmd.Parameters.AddWithValue("@Salary", funcionario.Salary);

                        var reader = await cmd.ExecuteScalarAsync();
                    }

                }

                return new DefaultResponse<object> {
                    Success = true,
                    Message = $@"INFO - Funcionario {funcionario.Name} - {funcionario.CPF} foi incerido com sucesso",
                };
            } 
            catch(MySqlException ex) when (ex.Number == 1062)
            {
                return new DefaultResponse<object>
                {
                    Success = false,
                    Message = $@"ERROR - Funcionario {funcionario.Name} - {funcionario.CPF} ja foi registrado anteriormente",
                };
            }
            catch(Exception) {
                throw;
            }
        }

        public async Task<List<FuncionariosEntity>> GetAllFuncionarios()
        {
            var funcionarios = new List<FuncionariosEntity>(); 
            try
            {
                using (var con = new MySqlConnection(_connectionString))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = $@"SELECT id, name, age, CPF, entryDate, salary FROM funcionarios;";

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                funcionarios.Add(new FuncionariosEntity
                                {
                                    Id = reader.GetInt32("id"),
                                    Name = reader.GetString("name"),
                                    Age =  reader.GetInt32("age"),
                                    CPF = reader.GetString("CPF"),
                                    EntryDate = reader.GetDateTime("entryDate").ToString("dd/MM/yyyy"),
                                    Salary = reader.GetDecimal("salary"),
                                });
                            }
                        }
                    }
                }

                return funcionarios;
            } catch(Exception)
            {
                throw;
            }
        }

    }
}
