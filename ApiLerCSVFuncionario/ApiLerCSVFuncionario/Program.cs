using APILerCSVFuncionario.Domain.Interfaces.Services;
using ApiLerCSVFuncionario.Domain.Interfaces.Repository;
using APILerCSVFuncionario.Domain.Interfaces.Repository;
using ApiLerCSVFuncionario.Infrastructure.Files.Readers;
using ApiLerCSVFuncionario.Infrastructure.Data.Repository;
using ApiLerCSVFuncionario.Aplications.Services;


namespace ApiLerCSVFuncionario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("connection");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            // Add Services and Repositories
            builder.Services.AddScoped<ILerArquivoCSVFuncionariosServices, LerAquivoCSVFuncionariosServices>();
            builder.Services.AddScoped<ICSVFuncionariosReader, CSVFuncionariosReader>();

            builder.Services.AddScoped<IFuncionariosRepository>(sp => new FuncionariosRepository(connectionString));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}