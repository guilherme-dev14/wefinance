using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using DotNetEnv;
using System;

namespace WeFinance.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Carrega as variáveis do .env
            Env.Load();
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}