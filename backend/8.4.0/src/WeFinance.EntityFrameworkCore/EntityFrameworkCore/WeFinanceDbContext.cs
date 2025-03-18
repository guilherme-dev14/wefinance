using Abp.EntityFrameworkCore;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using WeFinance.Models;
namespace WeFinance.EntityFrameworkCore
{
    public class WeFinanceDbContext : AbpDbContext
    {

        public DbSet<User> Users { get; set; }
        public WeFinanceDbContext(DbContextOptions<WeFinanceDbContext> options)
            : base(options)
        {
        }

        


    }
}
