using WeFinance.Configuration;
using WeFinance.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WeFinance.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class WeFinanceDbContextFactory : IDesignTimeDbContextFactory<WeFinanceDbContext>
    {
        public WeFinanceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WeFinanceDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(WeFinanceConsts.ConnectionStringName)
            );

            return new WeFinanceDbContext(builder.Options);
        }
    }
}