using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace WeFinance.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<WeFinanceDbContext> builder, 
            string connectionString
            )
        {
            //comando para postgre
            //dbContextOptions.UseNpgsql(connectionString);
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WeFinanceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
