using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using DotNetEnv;
using System;
using Npgsql;
using Microsoft.Extensions.Logging;

namespace WeFinance.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Env.Load();
                var envPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "credenciais.env");

                Env.Load(envPath);


                var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");




                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                }

                var host = WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar a aplicação: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}