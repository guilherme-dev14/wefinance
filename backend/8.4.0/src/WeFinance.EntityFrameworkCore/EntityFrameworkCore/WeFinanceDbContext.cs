using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WeFinance.EntityFrameworkCore
{
    public class WeFinanceDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public WeFinanceDbContext(DbContextOptions<WeFinanceDbContext> options) 
            : base(options)
        {

        }
    }
}
