using LordSolutions.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LordSolutions.Data.Context
{
    public class LordSolutionsDbContext : DbContext, ILordSolutionsDbContext
    {
        private readonly IConfiguration config;

        public LordSolutionsDbContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Cliente> clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString(name: "MSSQL")); ;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
