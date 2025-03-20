using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.IO;
using DotNetEnv;
using Microsoft.Extensions.Configuration;
using WeFinance.Configuration;
using WeFinance.Web;

namespace WeFinance.EntityFrameworkCore
{
    public class WeFinanceDbContextFactory : IDesignTimeDbContextFactory<WeFinanceDbContext>
    {
        public WeFinanceDbContext CreateDbContext(string[] args)
        {
            // Carregar o arquivo .env
            //  var envPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "credenciais.env");

            //if (File.Exists(envPath))
            //{
            //    Env.Load(envPath);
            //}
            //else
            //{
            //    Env.Load();
            //}
            //var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            var builder = new DbContextOptionsBuilder<WeFinanceDbContext>();

            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(builder, configuration.GetConnectionString(WeFinanceConsts.ConnectionStringName));

            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    throw new InvalidOperationException(
            //        "A string de conexão não foi encontrada. Certifique-se de que a variável DB_CONNECTION_STRING está definida no arquivo .env.");
            //}

            //var optionsBuilder = new DbContextOptionsBuilder<WeFinanceDbContext>();

            //// Usar postgre
            ////optionsBuilder.UseNpgsql(connectionString);

            //optionsBuilder.UseSqlServer(connectionString);

            return new WeFinanceDbContext(builder.Options);
        }
    }
}