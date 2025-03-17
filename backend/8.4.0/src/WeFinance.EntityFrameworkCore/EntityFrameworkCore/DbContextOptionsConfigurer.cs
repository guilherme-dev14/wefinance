using Microsoft.EntityFrameworkCore;

namespace WeFinance.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<WeFinanceDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for WeFinanceDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
