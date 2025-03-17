using Abp.EntityFrameworkCore;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace WeFinance.EntityFrameworkCore
{
    public class WeFinanceDbContext : AbpDbContext
    {

        public WeFinanceDbContext(DbContextOptions<WeFinanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuarios.User> Users { get; set; }


    }
}
